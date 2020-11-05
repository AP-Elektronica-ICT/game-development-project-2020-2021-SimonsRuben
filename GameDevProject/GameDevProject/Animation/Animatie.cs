using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation
{
    class Animatie
    {
        protected List<AnimationFrame> frames;
        public AnimationFrame CurrentFrame { get; set; }

        private int counter;

        private double framemovement = 0;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }
        public virtual void  AddFrame(AnimationFrame animationframe)
        {
            frames.Add(animationframe);
            CurrentFrame = frames[0];
        }
        public virtual void update(GameTime Gametime,ITransform entity)
        {
            CurrentFrame = frames[counter];
            framemovement += CurrentFrame.SourceRectangle.Width * Gametime.ElapsedGameTime.TotalSeconds;
            if (framemovement >= CurrentFrame.SourceRectangle.Width / 7)
            {
                counter++;
                framemovement = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }

        }
    }
}
