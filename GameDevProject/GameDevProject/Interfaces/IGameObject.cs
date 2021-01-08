using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IGameObject
    {

        void Update(GameTime gametime);
        void Draw(SpriteBatch spritebatch);
    }
}
