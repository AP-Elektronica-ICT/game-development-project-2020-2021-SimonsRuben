
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

}
}
