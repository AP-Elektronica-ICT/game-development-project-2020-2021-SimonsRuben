using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class HeroAnimations : IAnimation
    {
        private Animatie attack = new Animatie();
        private Animatie idle = new Animatie();
        private Animatie run = new Animatie();

        public Animatie Attack()
        {
            throw new NotImplementedException();
            return attack;
        }

        public Animatie Idle()
        {
            
            idle.AddFrame(new AnimationFrame(new Rectangle(296, 44, 25, 30)));
            idle.AddFrame(new AnimationFrame(new Rectangle(245, 44, 25, 30)));
            idle.AddFrame(new AnimationFrame(new Rectangle(196, 44, 25, 30)));
            idle.AddFrame(new AnimationFrame(new Rectangle(144, 44, 25, 30)));
            idle.AddFrame(new AnimationFrame(new Rectangle(96, 44, 25, 30)));
            idle.AddFrame(new AnimationFrame(new Rectangle(46, 44, 25, 30)));
            return idle;
        }

        public Animatie Run()
        {
            run.AddFrame(new AnimationFrame(new Rectangle(64, 44, 25, 30)));
            run.AddFrame(new AnimationFrame(new Rectangle(114, 44, 25, 30)));
            run.AddFrame(new AnimationFrame(new Rectangle(164, 44, 25, 30)));
            run.AddFrame(new AnimationFrame(new Rectangle(215, 44, 25, 30)));
            run.AddFrame(new AnimationFrame(new Rectangle(263, 44, 25, 30)));
            run.AddFrame(new AnimationFrame(new Rectangle(313, 44, 25, 30)));
            return run;
        }
    }
}
