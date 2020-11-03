using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class HeroAnimations : IAnimation
    {


        public Animatie CreateLeftAttack()
        {
            throw new NotImplementedException();
        }
        public Animatie CreateRightAttack()
        {
            throw new NotImplementedException();
        }

        public Animatie CreateLeftIdle()
        {
            throw new NotImplementedException();
        }

        public Animatie CreateRightIdle()
        {
            throw new NotImplementedException();
        }


        public Animatie CreateLeftRun()
        {
            Animatie runL = new Animatie();
            runL.AddFrame(new AnimationFrame(new Rectangle(296, 44, 25, 30)));
            runL.AddFrame(new AnimationFrame(new Rectangle(245, 44, 25, 30)));
            runL.AddFrame(new AnimationFrame(new Rectangle(196, 44, 25, 30)));
            runL.AddFrame(new AnimationFrame(new Rectangle(144, 44, 25, 30)));
            runL.AddFrame(new AnimationFrame(new Rectangle(96, 44, 25, 30)));
            runL.AddFrame(new AnimationFrame(new Rectangle(46, 44, 25, 30)));
            return runL;
        }
        
        public Animatie CreateRightRun()
        {
            Animatie runR = new Animatie();
            runR.AddFrame(new AnimationFrame(new Rectangle(64, 44, 25, 30)));
            runR.AddFrame(new AnimationFrame(new Rectangle(114, 44, 25, 30)));
            runR.AddFrame(new AnimationFrame(new Rectangle(164, 44, 25, 30)));
            runR.AddFrame(new AnimationFrame(new Rectangle(215, 44, 25, 30)));
            runR.AddFrame(new AnimationFrame(new Rectangle(263, 44, 25, 30)));
            runR.AddFrame(new AnimationFrame(new Rectangle(313, 44, 25, 30)));
            return runR;
        }
            

        public List<Animatie> Attack()
        {
            List<Animatie> Attack = new List<Animatie>();
            Attack.Add(CreateLeftAttack());
            Attack.Add(CreateRightAttack());
            throw new NotImplementedException();
        }

        public List<Animatie> Idle()
        {
            List<Animatie> Idle = new List<Animatie>();
            Idle.Add(CreateLeftIdle());
            Idle.Add(CreateRightIdle());
            throw new NotImplementedException();
        }

        public List<Animatie> Run()
        {
            List<Animatie> run = new List<Animatie>();
            run.Add(CreateLeftRun());
            run.Add(CreateRightRun());
            return run;
        }

     
    }
}
