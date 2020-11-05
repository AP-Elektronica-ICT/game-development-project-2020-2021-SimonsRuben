using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Animation
{
    class JumpingAnimatie : Animatie
    {
        protected List<AnimationFrame> frames;
        public new AnimationFrame CurrentFrame { get; set; }

        private int counter;

        private double framemovement = 0;

        public JumpingAnimatie()
        {

            frames = new List<AnimationFrame>();
            counter = 0;
        }
        public override void AddFrame(AnimationFrame animationframe)
        {

            base.AddFrame(animationframe);

            frames = base.frames;
            CurrentFrame = frames[0];
        }
        public override void update(GameTime Gametime,ITransform entity)
        {
            
            if (entity.VerticalMovement.Y > 0)
            {
                base.CurrentFrame = frames[1];
            }
            else
            {
                base.CurrentFrame = frames[0];
            }
        }
    }
}
