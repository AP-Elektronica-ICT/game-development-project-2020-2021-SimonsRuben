using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TiledSharp;
using System.Diagnostics;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Texture2D> Herotextures;
        Hero hero;




        TmxMap map;
        Texture2D tileset;
        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
        int tilesetTilesHigh;
        List<Rectangle> collisions = new List<Rectangle>();




        Texture2D testtext;

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
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Herotextures = new List<Texture2D>();
            Herotextures.Add(Content.Load<Texture2D>("HeroLeft"));
            Herotextures.Add(Content.Load<Texture2D>("HeroRight"));


            testtext = new Texture2D(GraphicsDevice, 1, 1);
            testtext.SetData(new Color[] { Color.DarkSlateGray });

            InitializeGameObject();
            loadmapcontent();
            
            // TODO: use this.Content to load your game content here
        }
        private void InitializeGameObject()
        {
            hero = new Hero(Herotextures);
        }

        private void loadmapcontent()
        {
            map = new TmxMap("Content/test.tmx");
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;

            //Debug.WriteLine(map.ObjectGroups.Count);

            foreach (var o in map.ObjectGroups[0].Objects)
            {
                collisions.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }
            
            Debug.WriteLine(collisions.Count);
                
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

            _spriteBatch.End();
            foreach (Rectangle collisionobject in collisions)
            {
                if (CheckCollision(hero.CollisionRectangle, collisionobject))
                {
                    Debug.WriteLine(collisionobject.Location);
                }
            }

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
        private bool CheckCollision(Rectangle entity1,Rectangle entity2)
        {
            if (entity1.Intersects(entity2))
            {
                return true;
            }
            return false;
        }
    }
}
