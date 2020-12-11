using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TiledSharp;
using System.Diagnostics;
using GameDevProject.Detections;
using GameDevProject.World;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Texture2D> Herotextures;
        Hero hero;
        CollisionDetection collisiondetect;


        Texture2D debugchar;

        TmxMap map;
        Texture2D tileset;

        string[] AllRooms = { "StartRoom", "CentralRoom", "BottemRoom", "TopRoom", "EndingRoom" };
        




        Wereld wereld;
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
            Herotextures = new List<Texture2D>();
            Herotextures.Add(Content.Load<Texture2D>("Hero/HeroLeft"));
            Herotextures.Add(Content.Load<Texture2D>("Hero/HeroRight"));

            debugchar = new Texture2D(GraphicsDevice, 1, 1);
            debugchar.SetData(new Color[] { Color.DarkSlateGray });


            wereld = new Wereld(loadmapcontent());
            loadmapcontent();
            collisiondetect = new CollisionDetection(wereld.ActiveRoom.GetCollisions());
            InitializeGameObject();

            // TODO: use this.Content to load your game content here
        }
        private void InitializeGameObject()
        {
            hero = new Hero(Herotextures,collisiondetect);
            hero.Spawn(wereld.ActiveRoom.GetSpawn());
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
                world.Add(new Room(map, tileset));
            }
            return world;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);
            collisiondetect.walls = wereld.ActiveRoom.GetCollisions();

            wereld.Update(hero);

            
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
            wereld.ActiveRoom.Draw(_spriteBatch);
            //_spriteBatch.Draw(debugchar, hero.CollisionRectangle, Color.White);
            hero.Draw(_spriteBatch);


            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}
