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
using GameDevProject.Detections;

namespace GameDevProject 
{
    public enum LoopRichting { links, rechts };
    public enum CharState { idle,run,attack,jumping};
    class Hero : IGameObject, ITransform, IEntity
    {
        public const int height = 60;
        public const int Width = 50;

        
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
        public Rectangle CollisionRectangle
        {
            get { return _CollisionRectangle; }
            set { _CollisionRectangle = value; }
        }

        private Rectangle _CollisionRectangle;





        public Hero(List<Texture2D> textures,CollisionDetection objects)
        {
            Position = new Vector2(400, 400);
            VerticalMovement = new Vector2(0, 0);// X: verticalmovement => 1 = ja          0= nee    Y: current jump speed
            HorizontalMovement = new Vector2(0, 4);// X: richting -1 => links 0=> stil 1=> rechts    Y: Current movespeed
            status = CharState.idle;
            richting = LoopRichting.rechts;
            herotexture = textures;


            animations = new List<List<Animatie>>();
            heroanimations = new HeroAnimations();
            animations.Add(heroanimations.Idle());
            animations.Add(heroanimations.Run());
            animations.Add(heroanimations.Attack());
            animations.Add(heroanimations.Jump());
            
            this.inputreader = new KeyboardReader();
            this.movecommand = new MoveCommand(objects);

            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Hero.Width, Hero.height);

        }
        public void Spawn(Vector2 pos)
        {
            this.Position = pos;
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
            inputreader.ReadAttack();
            _CollisionRectangle.X = (int)Position.X;
            _CollisionRectangle.Y = (int)Position.Y;

        }

        private void StatePicker()
        {
            if (status != CharState.attack)
            {
              
                if (this.VerticalMovement.X == 1 )
                {
                    status = CharState.jumping;
                }
                else
                {
                    if (this.HorizontalMovement.X != 0)
                    {
                        status = CharState.run;
                    }
                    else
                    {
                        status = CharState.idle;
                    }

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
            movecommand.ExecuteVertical(this);   
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
