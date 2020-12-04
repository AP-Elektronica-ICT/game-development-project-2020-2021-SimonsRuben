using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation
{
    class AttackAnimatie : Animatie
    {


        private int counter;

        private double framemovement = 0;

        public AttackAnimatie()
        {
            frames = new List<AnimationFrame>();
        }
        public override void AddFrame(AnimationFrame animationframe)
        {
            base.AddFrame(animationframe);

            frames = base.frames;
            CurrentFrame = frames[0];
        }
        public override void update(GameTime Gametime, ITransform entity)
        {
            base.CurrentFrame = frames[counter];
            framemovement += CurrentFrame.SourceRectangle.Width * Gametime.ElapsedGameTime.TotalSeconds;
            if (framemovement >= CurrentFrame.SourceRectangle.Width / 9)// 7 is standaard 9 is sneller
            {
                counter++;
                framemovement = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
                Hero.status = CharState.idle;
            }

        }
    }
}
