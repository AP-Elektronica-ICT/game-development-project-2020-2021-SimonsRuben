using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Menu
{
    public abstract class State
    {
        #region Fields
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;
        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch _spriteBatch);
        //public abstract void PostUpdate(GameTime gameTime); voor als er ooit post update nodig in de verschillende game states
        public State(Game1 game , GraphicsDevice graphicsDevice,ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }
        public abstract void Update(GameTime gameTime);
        #endregion


    }
}