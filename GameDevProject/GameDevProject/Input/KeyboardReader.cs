using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input
{
    class KeyboardReader : IinputReader
    {
        public Vector2 Readinput()
        {
            var direction = new Vector2();
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);

            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
            }
            return direction;
        }
    }
}
