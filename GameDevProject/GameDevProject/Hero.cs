using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Animation;
using Microsoft.Xna.Framework;
using GameDevProject.Animation.AnimationCreators;
using GameDevProject.Input;
using GameDevProject.Command;
using GameDevProject.Interfaces;
using System.Diagnostics;

namespace GameDevProject 
{
    public enum LoopRichting { links, rechts };
    class Hero : IGameObject, ITransform
    {
        
        HeroAnimations heroanimations;
        List<Texture2D> herotexture;
        List<Animatie> run;
        List<Animatie> idle;
        List<Animatie> attack;
        public LoopRichting richting;
        private IinputReader inputreader;
        private IGameCommand movecommand;
        public Vector2 Position { get; set; }


       

        public Hero(List<Texture2D> textures)
        {           
            richting = LoopRichting.rechts;
            herotexture = textures;   
            heroanimations = new HeroAnimations();
            run = heroanimations.Run();
            //idle = heroanimations.Idle(); animaties nog toevoegen
            //attack = heroanimations.Attack();animaties nog toevoegen
            this.inputreader = new KeyboardReader();
            this.movecommand = new MoveCommand();



           

            


        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(herotexture[(int)richting], Position, run[(int)richting].CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
            run[(int)richting].update(gametime);
            MoveKeyboard(inputreader.Readinput());


        }


        private void MoveKeyboard(Vector2 _direction)
        {
            if (_direction.X >0)
            {
                this.richting = LoopRichting.rechts;
            }
            else if (_direction.X < 0)
            {
                this.richting = LoopRichting.links;
            }

            movecommand.Execute(this, _direction);
        }
    }
}
