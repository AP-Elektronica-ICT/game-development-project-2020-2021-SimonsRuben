
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface ITransform
    {
        Vector2 HorizontalMovement { get; set; }
        Vector2 VerticalMovement { get; set; }

       Vector2 Position { get; set; }

        public Rectangle CollisionRectangle { get; set; }

        public CharState status { get; set; }

        public LoopRichting richting { get; set; }
        
        public Vector2 AttackRange { get; set; }

       

    }
}
