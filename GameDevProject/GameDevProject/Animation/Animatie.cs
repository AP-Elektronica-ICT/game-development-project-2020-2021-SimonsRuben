using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Animation
{
    class Animatie
    {
        private List<AnimationFrame> frames;
        public AnimationFrame CurrentFrame { get; set; }

        private int counter;

        private double framemovement = 0;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddFrame(AnimationFrame animationframe)
        {
            frames.Add(animationframe);
            CurrentFrame = frames[0];
        }
        public void update(GameTime Gametime)
        {
            CurrentFrame = frames[counter];
            framemovement += CurrentFrame.SourceRectangle.Width * Gametime.ElapsedGameTime.TotalSeconds;
            if (framemovement >= CurrentFrame.SourceRectangle.Width / 5)
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
