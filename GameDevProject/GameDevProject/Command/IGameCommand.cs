using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Text;

namespace GameDevProject.Command
{
    interface IGameCommand
    {
        void Execute(ITransform transform, Vector2 direction);
    }
}
