using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Text;

namespace GameDevProject.Command
{
    interface IGameCommand
    {
        void ExecuteHorizontal(ITransform transform, Vector2 direction);
        void ExecuteVertical(ITransform transform , float ground);
    }
}
