using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation
{
    interface IdeathAnimation
    {
        public List<Animatie> Death();
        Animatie CreateLeftDeath();
        Animatie CreateRightDeath();
    }
}
