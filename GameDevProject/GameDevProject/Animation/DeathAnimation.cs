using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GameDevProject.Animation
{
    class DeathAnimation : Animatie
    {

        private int counter;

        private double framemovement = 0;

        public DeathAnimation()
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
            
            if (counter < frames.Count)
            {
                base.CurrentFrame = frames[counter];
                framemovement += CurrentFrame.SourceRectangle.Width * Gametime.ElapsedGameTime.TotalSeconds;
                if (framemovement >= CurrentFrame.SourceRectangle.Width / 4)// 4 is standaard
                {
                    counter++;
                    framemovement = 0;
                    
                }
            }
        }
    }
}
