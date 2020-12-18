using GameDevProject.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class SpearManAnimations : IAnimation, IjumpingAnimation
    {
        private int height = Spearman.height;
        private int width = Spearman.Width;
        
        public List<Animatie> Attack()
        {
            List<Animatie> Attack = new List<Animatie>();
            Attack.Add(CreateLeftAttack());
            Attack.Add(CreateRightAttack());
            return Attack;
        }

        public Animatie CreateLeftAttack()
        {
            Animatie AttackL = new AttackAnimatie();
            AttackL.AddFrame(new AnimationFrame(new Rectangle(2614, 35, width, height)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(1262, 35, 84, 82)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(1167, 35, 77, 73)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(1070, 35, 79, 73)));
            AttackL.AddFrame(new AnimationFrame(new Rectangle(981, 35, 71, 73)));
            return AttackL;
        }

        public Animatie CreateLeftIdle()
        {
            Animatie idleL = new Animatie();
            idleL.AddFrame(new AnimationFrame(new Rectangle(2614, 35, width, height)));
            idleL.AddFrame(new AnimationFrame(new Rectangle(2326, 35, width, height)));
            return idleL;
        }

        public Animatie CreateLeftJump()
        {
            Animatie jumpL = new JumpingAnimatie();
            jumpL.AddFrame(new AnimationFrame(new Rectangle(407, 35, width, height)));
            jumpL.AddFrame(new AnimationFrame(new Rectangle(313, 35, width, height)));
            return jumpL;
        }

        public Animatie CreateLeftRun()
        {
            Animatie runL = new Animatie();
            runL.AddFrame(new AnimationFrame(new Rectangle(1753, 35, width, height)));
            runL.AddFrame(new AnimationFrame(new Rectangle(1656, 35, width, height)));
            runL.AddFrame(new AnimationFrame(new Rectangle(1560, 35, width, height)));
            runL.AddFrame(new AnimationFrame(new Rectangle(1462, 35, width, height)));

            return runL;
        }

        public Animatie CreateRightAttack()
        {
            Animatie AttackR = new AttackAnimatie();
            AttackR.AddFrame(new AnimationFrame(new Rectangle(196, 35, width, height)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(1345, 35, 84, 82)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(1444, 35, 77, 73)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(1539, 35, 79, 73)));
            AttackR.AddFrame(new AnimationFrame(new Rectangle(1635, 35, 71, 73)));

            return AttackR;
        }

        public Animatie CreateRightIdle()
        {
            Animatie idleR = new Animatie();
            idleR.AddFrame(new AnimationFrame(new Rectangle(196, 35, width, height)));
            idleR.AddFrame(new AnimationFrame(new Rectangle(292, 35, width,height)));
            return idleR;
        }

        public Animatie CreateRightJump()
        {
            Animatie jumpR = new JumpingAnimatie();
            jumpR.AddFrame(new AnimationFrame(new Rectangle(2212, 35, width, height)));
            jumpR.AddFrame(new AnimationFrame(new Rectangle(2307, 35, width, height)));
            return jumpR;
        }

        public Animatie CreateRightRun()
        {
            Animatie runR = new Animatie();
            runR.AddFrame(new AnimationFrame(new Rectangle(868, 35, width, height)));
            runR.AddFrame(new AnimationFrame(new Rectangle(964, 35, width, height)));
            runR.AddFrame(new AnimationFrame(new Rectangle(1059, 35, width, height)));
            runR.AddFrame(new AnimationFrame(new Rectangle(1155, 35, width, height)));

            return runR;
        }

        public List<Animatie> Idle()
        {
            List<Animatie> Idle = new List<Animatie>();
            Idle.Add(CreateLeftIdle());
            Idle.Add(CreateRightIdle());
            return Idle;
        }

        public List<Animatie> Jump()
        {
            List<Animatie> jumping = new List<Animatie>();
            jumping.Add(CreateLeftJump());
            jumping.Add(CreateRightJump());
            return jumping;
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
