using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Animation.AnimationCreators
{
    class AnimationFactory
    {
        private string[,] StatusAnimation = new string[,] {{"idle","run","attack","jumping","death" },{ "Animatie", "Animatie", "AttackAnimatie", "JumpingAnimatie", "DeathAnimation" } };

     private Animatie CreateAnimation(string type, int[,] frames)
        {
            try
            {
                Animatie temp = (Animatie)Activator.CreateInstance(Type.GetType($"GameDevProject.Animation.{type}"), new Object[] { });
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
            for (int i = 0; i < StatusAnimation.GetLength(1); i++)
            {
                complete.Add(CreateBothAnimations(StatusAnimation[1, i], animationEntity.GetAnimationList(i * 2), animationEntity.GetAnimationList((i * 2) + 1)));
                /*Animaties worden hier aangemaakt met behulp van een for om zo door elke status te loopen
                 * elke status heeft zijn eigen soort animatie die string wordt gebruikt om de juist soort animatie aan te maken
                 * de lijst van een animation entity is alle verschillende animatie op volgorde er in steken
                 * het volgt de volgorde van de statussen en de volgorde van eerst links dan rechts
                 * de index gaat er dan als volgt uitzien (idle links = 0, idle rechts = 1 , run links = 2 , run rechts = 3 ,...)
                 * er zijn 5 verschillende status op dit moment dus loopen we 5 keer en per groep van 2 geven we de juist getallen mee voor de animatie te maken
                 * 
                 * 
                 * */

            }

            return complete;
        }
    }
}
