using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class AnimationFactory
    {
        // hier worden alle animaties gemaakt met een factory (try catch filmpje 14)

        private Animatie CreateAnimation(string type, int[,] frames)
        {
            Debug.WriteLine($@"
DEBUG FACTORY
TYPE = {type}
frames = {frames.GetLength(0)}
");
            try
            {
                Animatie temp = (Animatie)Activator.CreateInstance(Type.GetType($"GameDevProject.Animation.{type}"), new Object[] { });
                Debug.WriteLine(temp.ToString());
                for (int i = 0; i < frames.GetLength(0); i++)
                {
                    temp.AddFrame(new AnimationFrame(new Rectangle(frames[i, 0], frames[i, 1], frames[i, 2], frames[i, 3])));

                }
                return temp;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
                return null;
            }

        }

        private List<Animatie> CreateBothAnimations(string type, int[,] framesleft, int[,] framesright)
        {
            List<Animatie> temp = new List<Animatie>();
            temp.Add(CreateAnimation(type, framesleft));
            temp.Add(CreateAnimation(type, framesright));
            return temp;
        }

        public List<List<Animatie>> CreateTotalAnimation(AnimationEntity animationEntity)
        {
            List<List<Animatie>> complete = new List<List<Animatie>>();
            complete.Add(Idle(animationEntity.idleL,animationEntity.idleR));
            complete.Add(Run(animationEntity.runL,animationEntity.runR));
            complete.Add(Attack(animationEntity.AttackL,animationEntity.AttackR));
            complete.Add(Jump(animationEntity.jumpingL,animationEntity.jumpingR));
            complete.Add(Death(animationEntity.deathL,animationEntity.deathR));
            return complete;
        }
        private List<Animatie> Idle(int[,] left,int[,] right)
        {
            string type = "Animatie";
            return CreateBothAnimations(type, left, right);
        }
        private List<Animatie> Run(int[,] left, int[,] right)
        {
            string type = "Animatie";
            return CreateBothAnimations(type, left, right);
        }
        private List<Animatie> Attack(int[,] left, int[,] right)
        {
            string type = "AttackAnimatie";
            return CreateBothAnimations(type, left, right);
        }
        private List<Animatie> Jump(int[,] left, int[,] right)
        {
            string type = "JumpingAnimatie";
            return CreateBothAnimations(type, left, right);
        }
        private List<Animatie> Death(int[,] left, int[,] right)
        {
            string type = "DeathAnimation";
            return CreateBothAnimations(type, left, right);
        }

    }
}
