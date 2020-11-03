using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using GameDevProject.Animation.AnimationCreators;

namespace GameDevProject
{
    class Hero
    {
        HeroAnimations heroanimations;
        Texture2D herotexture;
        
        Animatie run;

        public Hero(Texture2D right,Texture2D left)
        {
            herotexture = left;
            heroanimations = new HeroAnimations();
            run = heroanimations.Idle();

            


        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(herotexture, new Vector2(10, 10), run.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
          run.update(gametime);
        }
    }
}
