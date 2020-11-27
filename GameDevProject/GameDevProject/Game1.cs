using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TiledSharp;
using System.Diagnostics;
using GameDevProject.Detections;

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
        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
        int tilesetTilesHigh;
        List<Rectangle> collisions = new List<Rectangle>();

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


            loadmapcontent();

            InitializeGameObject();

            // TODO: use this.Content to load your game content here
        }
        private void InitializeGameObject()
        {
            hero = new Hero(Herotextures,collisiondetect);
        }

        private void loadmapcontent()
        {
            //https://www.trccompsci.online/mediawiki/index.php/Using_a_tmx_map_in_monogame
            // the whole map is made with tiledsharp see above link for documentation
            map = new TmxMap("Content/map/StartRoom.tmx");
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;

            foreach (var o in map.ObjectGroups[0].Objects)
            {
                collisions.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }
            collisiondetect = new CollisionDetection(collisions);
            
                
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);

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
            drawmap();
            hero.Draw(_spriteBatch);


            //_spriteBatch.Draw(debugchar, hero.CollisionRectangle, Color.White);
            _spriteBatch.End();
            //collisiondetect.checkwallsandplatforms(hero.CollisionRectangle);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        private void drawmap()
        {
            for (int ji = 0; ji < map.Layers.Count; ji++)
            {
                
                for (var i = 0; i < map.Layers[ji].Tiles.Count; i++)
                {
                    int gid = map.Layers[ji].Tiles[i].Gid;

                    // Empty tile, do nothing
                    if (gid == 0)
                    {

                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                        float x = (i % map.Width) * map.TileWidth;
                        float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                        _spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                    }
                }
            }
            
        }
    }
}
