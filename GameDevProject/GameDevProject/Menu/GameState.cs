using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GameDevProject.Menu
{
    class GameState : State
    {
        public GameState(Game1 game,GraphicsDevice graphicsDevice,ContentManager content): base(game,graphicsDevice,content)
        {
            Debug.WriteLine("START GAME");
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            Debug.Write("Drawing Game");
        }

        public override void PostUpdate(GameTime gameTime)
        {
           
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
