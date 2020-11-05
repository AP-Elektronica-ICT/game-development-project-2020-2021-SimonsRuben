using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation
{
    interface IjumpingAnimation
    {
        public List<Animatie> Jump();
        Animatie CreateLeftJump();
        Animatie CreateRightJump();
    }
}
