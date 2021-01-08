using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Menu
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gametime, SpriteBatch spritebatch);
        public abstract void Update(GameTime gameTime);
    }
}
