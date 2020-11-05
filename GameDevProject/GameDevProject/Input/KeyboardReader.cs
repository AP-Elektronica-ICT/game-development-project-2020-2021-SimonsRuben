using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input
{
    class KeyboardReader : IinputReader
    {
        
        public void IsJumping(ITransform transform)
        {
            KeyboardState keyState = Keyboard.GetState();
            
            if (keyState.IsKeyDown(Keys.Space)&& Hero.status != CharState.jumping)
            {
                Hero.status = CharState.jumping;
                transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, -6f);
            }
            
        }

        public Vector2 ReadAttack()
        {
            throw new NotImplementedException();
        }

        

        public Vector2 ReadLeftRight()
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
