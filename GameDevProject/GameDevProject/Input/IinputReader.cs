using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input
{
    interface IinputReader
    {
        Vector2 ReadLeftRight();
        void IsJumping(ITransform transform);
        void ReadAttack();
        
    }
}
