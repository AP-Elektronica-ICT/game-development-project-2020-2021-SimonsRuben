using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation
{
    interface IAnimation
    {

        public List<Animatie> Idle();
        public List<Animatie> Run();
        public List<Animatie> Attack();
        Animatie CreateLeftRun();
        Animatie CreateRightRun();
        Animatie CreateLeftAttack();
        Animatie CreateRightAttack();
        Animatie CreateLeftIdle();
        Animatie CreateRightIdle();


        

    }


       
}
