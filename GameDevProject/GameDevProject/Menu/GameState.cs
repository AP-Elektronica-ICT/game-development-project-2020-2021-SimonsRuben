using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using GameDevProject.Detections;
using TiledSharp;
using GameDevProject.World;
using GameDevProject.Entities;

namespace GameDevProject.Menu
{
    class GameState : State
    {
        private List<Texture2D> Herotextures;
        Hero hero;
        CollisionDetection collisiondetect;
        List<Texture2D> SpearMantextures;
        Texture2D debugchar;
        TmxMap map;
        Texture2D tileset;
        string[] AllRooms = { "StartRoom", "CentralRoom", "BottemRoom", "TopRoom", "EndingRoom" };
        HitDetections hitdetection;
        LevelPicker Levels;
        private int levelnumb;
        private List<Component> _components;
        #region LOADING GAME
        public GameState(Game1 game,GraphicsDevice graphicsDevice,ContentManager content, int levelnumber): base(game,graphicsDevice,content)
        {
            Debug.WriteLine("START GAME");

            collisiondetect = new CollisionDetection();
            LoadSprites();
            InitializeGameObject();
            Levels = new LevelPicker(loadmapcontent(), hero, collisiondetect);

            collisiondetect.walls = Levels.GetActiveWereld().ActiveRoom.GetCollisions();
            hitdetection = new HitDetections(hero, Levels.GetActiveWereld().ActiveRoom.enemies);

            SetStartingLevel(levelnumber);
            MakeDeathScreen();

        }
        private void SetStartingLevel(int levelinput)
        {
            // check dat je niet naar een hoger level dan de game heeft kan gaan
            if (levelinput > Levels.GetAmountOfLevels())
            {
                Levels.SetLevel(Levels.GetAmountOfLevels());
                this.levelnumb = Levels.GetAmountOfLevels();
            }
            else
            {
                Levels.SetLevel(levelinput);
                this.levelnumb = levelinput;
            }
            
        }
        private void LoadSprites()
        {
            Herotextures = new List<Texture2D>();
            Herotextures.Add(_content.Load<Texture2D>("Sprites/HeroLeft"));
            Herotextures.Add(_content.Load<Texture2D>("Sprites/HeroRight"));

            /*debugchar = new Texture2D(GraphicsDevice, 1, 1);
            debugchar.SetData(new Color[] { Color.DarkSlateGray });*/


            SpearMantextures = new List<Texture2D>();
            SpearMantextures.Add(_content.Load<Texture2D>("Sprites/SpearManLeft"));
            SpearMantextures.Add(_content.Load<Texture2D>("Sprites/SpearManRight"));
            Spearman.textures = SpearMantextures;

        }
        private void InitializeGameObject()
        {
            collisiondetect = new CollisionDetection();
            hero = new Hero(Herotextures, collisiondetect);
        }
        private List<Room> loadmapcontent()
        {
            //https://www.trccompsci.online/mediawiki/index.php/Using_a_tmx_map_in_monogame
            // the whole map is made with tiledsharp see above link for documentation

            List<Room> world = new List<Room>();
            foreach (string room in AllRooms)
            {
                map = new TmxMap("Content/map/" + room + ".tmx");
                tileset = _content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
                world.Add(new Room(map, tileset, collisiondetect, hero));
            }
            return world;
        }


        private void MakeDeathScreen()
        {
            var buttonTexture = _content.Load<Texture2D>("menu/Button");
            var buttonFont = _content.Load<SpriteFont>("menu/Font");

            var TryAgain = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Try Again"
            };
            TryAgain.Click += TryAgain_Click;
            var MainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Main Menu"
            };
            MainMenuButton.Click += MainMenu_Click;

            _components = new List<Component>()
            {
                TryAgain,
                MainMenuButton
            };
        }
        #endregion
        private void TryAgain_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content, levelnumb));
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
        private void DrawDeath(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            foreach (var component in _components)
            {
                component.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();
        }
        private void UpdateDeath(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }



        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            collisiondetect.walls = Levels.GetActiveWereld().ActiveRoom.GetCollisions();

            Levels.Update(gameTime);

            hitdetection.update(Levels.GetActiveWereld().ActiveRoom.enemies);

            //check victory
            if (Levels.Done())
            {
                _game.ChangeState(new VictoryState(_game, _graphicsDevice, _content,levelnumb));
            }
            else if (hero.status == CharState.death)
            {
                // death screen
                UpdateDeath(gameTime);
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            //Debug.Write("Drawing Game");
            _spriteBatch.Begin();
            Levels.Draw(_spriteBatch);
            // _spriteBatch.Draw(debugchar,enemies[0].Attackbox, Color.White); werdt gebruikt voor debug hitboxen en collisions
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
            if (hero.status == CharState.death)
            {
                DrawDeath(gameTime,_spriteBatch);
            }
        }





    }
}
