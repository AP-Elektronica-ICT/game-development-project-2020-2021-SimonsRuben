using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TiledSharp;
using System.Diagnostics;
using GameDevProject.Detections;
using GameDevProject.World;
using GameDevProject.Entities;
using GameDevProject.Input;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
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
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 960;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            collisiondetect = new CollisionDetection();




            LoadSprites();
            InitializeGameObject();
            Levels = new LevelPicker(loadmapcontent(),hero,collisiondetect);

            
            
            collisiondetect.walls = Levels.GetActiveWereld().ActiveRoom.GetCollisions();
            hitdetection = new HitDetections(hero, Levels.GetActiveWereld().ActiveRoom.enemies);
            //hero.Spawn(Levels.GetActiveWereld().ActiveRoom.GetSpawn());

            // TODO: use this.Content to load your game content here
        }
        private void LoadSprites()
        {
            Herotextures = new List<Texture2D>();
            Herotextures.Add(Content.Load<Texture2D>("Sprites/HeroLeft"));
            Herotextures.Add(Content.Load<Texture2D>("Sprites/HeroRight"));

            debugchar = new Texture2D(GraphicsDevice, 1, 1);
            debugchar.SetData(new Color[] { Color.DarkSlateGray });


            SpearMantextures = new List<Texture2D>();
            SpearMantextures.Add(Content.Load<Texture2D>("Sprites/SpearManLeft"));
            SpearMantextures.Add(Content.Load<Texture2D>("Sprites/SpearManRight"));
            Spearman.textures = SpearMantextures;
            
        }
        private void InitializeGameObject()
        {
            collisiondetect = new CollisionDetection();
            hero = new Hero(Herotextures,collisiondetect);
        }


        private List<Room> loadmapcontent()
        {
            //https://www.trccompsci.online/mediawiki/index.php/Using_a_tmx_map_in_monogame
            // the whole map is made with tiledsharp see above link for documentation

            List<Room> world = new List<Room>();
            foreach (string room in AllRooms)
            {
                map = new TmxMap("Content/map/" + room + ".tmx");
                tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
                world.Add(new Room(map, tileset,collisiondetect,hero));
            }
            return world;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);
            collisiondetect.walls = Levels.GetActiveWereld().ActiveRoom.GetCollisions();

            Levels.Update(gameTime);

            hitdetection.update(Levels.GetActiveWereld().ActiveRoom.enemies);

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            /*
            _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,Matrix.CreateScale(1.5f));
            de lijn hierboven zal alle sprites op het scherm vergroten naar 1.5 keer de orginele grote

            */
            _spriteBatch.Begin();
            Levels.Draw(_spriteBatch);
           // _spriteBatch.Draw(debugchar,enemies[0].Attackbox, Color.White);

            hero.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}
