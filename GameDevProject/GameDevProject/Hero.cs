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
using Microsoft.Xna.Framework.Input;

namespace GameDevProject 
{
    public enum LoopRichting { links, rechts };
    public enum CharState { idle,run,attack,jumping};
    class Hero : IGameObject, ITransform
    {
        
        HeroAnimations heroanimations;
        List<Texture2D> herotexture;
        List<List<Animatie>> animations;
        public LoopRichting richting;
        static public CharState status;
        private IinputReader inputreader;
        private IGameCommand movecommand;
        public Vector2 Position { get; set; }
        public Vector2 HorizontalMovement { get; set; }
        public Vector2 VerticalMovement { get; set; }
        float startY;





        public Hero(List<Texture2D> textures)
        {
            Position = new Vector2(230, 200);
            VerticalMovement = new Vector2(0, 0);// X: -1 => naar beneden 0 => stil 1=>naar boven    Y: current jump speed
            HorizontalMovement = new Vector2(0, 2);// X: richting -1 => links 0=> stil 1=> rechts    Y: Current movespeed
            status = CharState.idle;
            richting = LoopRichting.rechts;
            herotexture = textures;
            animations = new List<List<Animatie>>();
            heroanimations = new HeroAnimations();
            animations.Add(heroanimations.Idle());
            animations.Add(heroanimations.Run());
            animations.Add(heroanimations.Idle());
            animations.Add(heroanimations.Jump());
            //animations.Add(heroanimations.Attack());animaties nog toevoegen
            this.inputreader = new KeyboardReader();
            this.movecommand = new MoveCommand();





            //jumping
            //Char loc, X/Y
            startY = Position.Y;//Starting position









        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            
            _spriteBatch.Draw(herotexture[(int)richting], Position, animations[(int)status][(int)richting].CurrentFrame.SourceRectangle, Color.White);
            
        }

        public void Update(GameTime gametime)
        {
            StatePicker();
            UpdateAnimations(gametime);
            MoveHorizontal(inputreader.ReadLeftRight());
            MoveVertical();



            


        }

        private void StatePicker()
        {
            if (status != CharState.jumping)
            {
                if (HorizontalMovement.X != 0)
                {
                    status = CharState.run;
                }
                else
                {
                    status = CharState.idle;
                }
            }
        }
        private void UpdateAnimations(GameTime gametime)
        {
            
            animations[(int)status][(int)richting].update(gametime,this);
        }


        private void MoveVertical()
        {
            inputreader.IsJumping(this);
            if (status == CharState.jumping)
            {

                movecommand.ExecuteVertical(this,startY);
                
            }

        }
        private void MoveHorizontal(Vector2 _direction)
        {
            HorizontalMovement = new Vector2(_direction.X, HorizontalMovement.Y);
            
                if (_direction.X > 0)
                {
                    this.richting = LoopRichting.rechts;
                }
                else if (_direction.X < 0)
                {
                    this.richting = LoopRichting.links;
                }

            movecommand.ExecuteHorizontal(this, _direction);
        }
    }
}
