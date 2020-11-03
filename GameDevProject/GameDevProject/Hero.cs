using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using GameDevProject.Animation.AnimationCreators;

namespace GameDevProject
{
    public enum LoopRichting { links, rechts };
    class Hero
    {
        
        HeroAnimations heroanimations;
        List<Texture2D> herotexture;
        List<Animatie> run;
        List<Animatie> idle;
        List<Animatie> attack;
        public LoopRichting richting;
        int teller = 0;


        public Hero(List<Texture2D> textures)
        {           
            richting = LoopRichting.rechts;
            herotexture = textures;   
            heroanimations = new HeroAnimations();
            run = heroanimations.Run();
            //idle = heroanimations.Idle(); animaties nog toevoegen
            //attack = heroanimations.Attack();animaties nog toevoegen


           

            


        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(herotexture[(int)richting], new Vector2(10, 10), run[(int)richting].CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
          run[(int)richting].update(gametime);


            // hieronder is het gewoon om de richting te testen
            teller++;
            if (teller > 600)
            {
                richting = LoopRichting.rechts;
                teller = 0;
            }
            else if (teller > 300)
            {
                richting = LoopRichting.links;
            }
        }
    }
}
