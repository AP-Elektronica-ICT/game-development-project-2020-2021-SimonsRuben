using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class HeroAnimations : IAnimation,IjumpingAnimation
    {

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
            throw new NotImplementedException();
        }
        public Animatie CreateRightAttack()
        {
            throw new NotImplementedException();
        }

        public Animatie CreateLeftIdle()
        {
            Animatie idleL = new Animatie();
            idleL.AddFrame(new AnimationFrame(new Rectangle(198, 5, 25, 30)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(248, 5, 25, 30)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(298, 5, 25, 30)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(348, 5, 25, 30)));
            return idleL;
        }

        public Animatie CreateRightIdle()
        {
            Animatie idleR = new Animatie();
            idleR.AddFrame(new AnimationFrame(new Rectangle(12, 5, 25, 30)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(62, 5, 25, 30)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(112, 5, 25, 30)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(162, 5, 25, 30)));
            return idleR;
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
            jumpL.AddFrame(new AnimationFrame(new Rectangle(246, 79, 25, 30)));
            jumpL.AddFrame(new AnimationFrame(new Rectangle(248, 113, 25, 30)));
            return jumpL;
        }

        public Animatie CreateRightJump()
        {
            Animatie jumpR = new JumpingAnimatie();
            jumpR.AddFrame(new AnimationFrame(new Rectangle(114, 80, 25, 30)));
            jumpR.AddFrame(new AnimationFrame(new Rectangle(115, 113, 25, 30)));
            return jumpR;
        }
    }
}
