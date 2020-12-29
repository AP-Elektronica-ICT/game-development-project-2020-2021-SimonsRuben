using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class HeroAnimations : IAnimation,IjumpingAnimation,IdeathAnimation
    {
        private int height = Hero.Width;
        private int width = Hero.height;
        public Animatie CreateAnimation(string animatie)
        {
            //Factory
            return null;
        }


        /*
         * 
         * HEEL DE ANIMATIE CREATOR VERANDEREN VIA HET FACTORY PATROON
         * ZIE DIGITAP VOOR INFO FACTORY
         * 
         * 
         * 
         * 
         * */

        public Animatie CreateLeftAttack()
        {
            Animatie AttackL = new AttackAnimatie();
            AttackL.AddFrame(new AnimationFrame(new Rectangle(660, 531, 100, width)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(566, 531, 100, 78)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(470, 531, 90, 70)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(370, 531, 90, 70)));
            return AttackL;
        }
        public Animatie CreateRightAttack()
        {
            Animatie AttackR = new AttackAnimatie();
           
            AttackR.AddFrame(new AnimationFrame(new Rectangle(22, 530, height, width)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(118, 530, 78, 78)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(204, 530, 101, 60)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(304, 530, 90, 60)));
           
            return AttackR;
        }

        public Animatie CreateLeftIdle()
        {
            Animatie idleL = new Animatie();
            idleL.AddFrame(new AnimationFrame(new Rectangle(396, 10, height, width)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(496, 10, height, width)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(596, 10, height, width)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(696, 10, height, width)));
            return idleL;
        }

        public Animatie CreateRightIdle()
        {
            Animatie idleR = new Animatie();
            idleR.AddFrame(new AnimationFrame(new Rectangle(24, 10, height, width)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(124, 10, height, width)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(224, 10, height, width)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(324, 10, height, width)));
            return idleR;
        }


        public Animatie CreateLeftRun()
        {
            Animatie runL = new Animatie();
            runL.AddFrame(new AnimationFrame(new Rectangle(592, 88, height, width)));
            runL.AddFrame(new AnimationFrame(new Rectangle(490, 88, height, width)));
            runL.AddFrame(new AnimationFrame(new Rectangle(392, 88, height, width)));
            runL.AddFrame(new AnimationFrame(new Rectangle(288, 88, height, width)));
            runL.AddFrame(new AnimationFrame(new Rectangle(192, 88, height, width)));
            runL.AddFrame(new AnimationFrame(new Rectangle(92, 88, height, width)));
            return runL;
        }
        
        public Animatie CreateRightRun()
        {
            Animatie runR = new Animatie();
            runR.AddFrame(new AnimationFrame(new Rectangle(128, 88, height, width)));
            runR.AddFrame(new AnimationFrame(new Rectangle(228, 88, height, width)));
            runR.AddFrame(new AnimationFrame(new Rectangle(328, 88, height, width)));
            runR.AddFrame(new AnimationFrame(new Rectangle(428, 88, height, width)));
            runR.AddFrame(new AnimationFrame(new Rectangle(528, 88, height, width)));
            runR.AddFrame(new AnimationFrame(new Rectangle(628, 88, height, width)));
            return runR;
        }
            

        public List<Animatie> Attack()
        {
            List<Animatie> Attack = new List<Animatie>();
            Attack.Add(CreateLeftAttack());
            Attack.Add(CreateRightAttack());
            return Attack;
            
        }

        public List<Animatie> Idle()
        {
            List<Animatie> Idle = new List<Animatie>();
            Idle.Add(CreateLeftIdle());
            Idle.Add(CreateRightIdle());
            return Idle;
        }

        public List<Animatie> Run()
        {
            List<Animatie> run = new List<Animatie>();
            run.Add(CreateLeftRun());
            run.Add(CreateRightRun());
            return run;
        }

        public List<Animatie> Jump()
        {
            List<Animatie> jumping = new List<Animatie>();
            jumping.Add(CreateLeftJump());
            jumping.Add(CreateRightJump());
            return jumping;
        }

        public Animatie CreateLeftJump()
        {
            Animatie jumpL = new JumpingAnimatie();
            jumpL.AddFrame(new AnimationFrame(new Rectangle(492, 158, height, width)));
            jumpL.AddFrame(new AnimationFrame(new Rectangle(496, 226, height, width)));
            return jumpL;
        }

        public Animatie CreateRightJump()
        {
            Animatie jumpR = new JumpingAnimatie();
            jumpR.AddFrame(new AnimationFrame(new Rectangle(228, 160, height, width)));
            jumpR.AddFrame(new AnimationFrame(new Rectangle(230, 226, height, width)));
            return jumpR;
        }

        public List<Animatie> Death()
        {
            List<Animatie> death = new List<Animatie>();
            death.Add(CreateLeftDeath());
            death.Add(CreateRightDeath());
            return death;
        }

        public Animatie CreateLeftDeath()
        {
            Animatie DieL = new DeathAnimation();
            DieL.AddFrame(new AnimationFrame(new Rectangle(493, 676, 45, width)));
            
            DieL.AddFrame(new AnimationFrame(new Rectangle(386, 676, 45, width)));
            DieL.AddFrame(new AnimationFrame(new Rectangle(286, 676, 45, width))); 

            return DieL;
        }

        public Animatie CreateRightDeath()
        {
            Animatie DieR = new DeathAnimation();
            DieR.AddFrame(new AnimationFrame(new Rectangle(231, 676, 45, width))); 
            DieR.AddFrame(new AnimationFrame(new Rectangle(334, 676, 45, width)));
            DieR.AddFrame(new AnimationFrame(new Rectangle(434, 676, 45, width)));
            return DieR;
        }
    }
}
