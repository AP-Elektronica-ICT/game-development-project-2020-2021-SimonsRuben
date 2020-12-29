using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    //idle,run,attack,jumping,death
    class AnimationEntity
    {
        public int[,] idleL { get; set; }
        public int[,] idleR { get; set; }
        public int[,] runL { get; set; }
        public int[,] runR { get; set; }
        public int[,] AttackL { get; set; }
        public int[,] AttackR { get; set; }
        public int[,] jumpingL { get; set; }
        public int[,] jumpingR { get; set; }
        public int[,] deathL { get; set; }
        public int[,] deathR { get; set; }

    }
}
