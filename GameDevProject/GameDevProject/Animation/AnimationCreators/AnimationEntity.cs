using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    //idle,run,attack,jumping,death
    class AnimationEntity
    {
        // dit is een animatie entity classe
        // hier slagen we alle info inverband met de animaties in en gebruiken we om zo solid en gemakkelijk mogelijk de animaties te maken
        
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

        private List<int[,]> AnimationList;
        
        public void CreateList()
        {
            this.AnimationList = new List<int[,]>();
            this.AnimationList.Add(idleL);
            this.AnimationList.Add(idleR);
            this.AnimationList.Add(runL);
            this.AnimationList.Add(runR);
            this.AnimationList.Add(AttackL);
            this.AnimationList.Add(AttackR);
            this.AnimationList.Add(jumpingL);
            this.AnimationList.Add(jumpingR);
            this.AnimationList.Add(deathL);
            this.AnimationList.Add(deathR);
        }

        public int[,] GetAnimationList(int indexnumber)
        {
            return this.AnimationList[indexnumber];
        }


    }
}
