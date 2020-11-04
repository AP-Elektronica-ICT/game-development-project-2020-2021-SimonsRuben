using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Command
{
    class MoveCommand :IGameCommand
    {
        public Vector2 speed;
        public MoveCommand()
        {
            this.speed = new Vector2(2, 0);
        }

        public void Execute(ITransform transform,Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
        }
    }
}
