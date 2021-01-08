using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Input
{
    class KeyboardReader : IinputReader
    {
        private ITransform player;
        public KeyboardReader(ITransform transformobject)
        {
            this.player = transformobject;
        }
        
        public void IsJumping()
        {
            KeyboardState keyState = Keyboard.GetState();
            
            if (keyState.IsKeyDown(Keys.Space)&& player.status != CharState.jumping && player.VerticalMovement.X == 0 )
            {
                player.VerticalMovement = new Vector2(1, -12f);
            }
        }

        public void ReadAttack()
        {
            KeyboardState keyState = Keyboard.GetState();
            
            if (keyState.IsKeyDown(Keys.X) && player.status != CharState.attack)
            {
                player.status = CharState.attack;
            }
            
        }

        

        public Vector2 ReadLeftRight()
        {
            Vector2 direction = new Vector2();
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
