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
    public enum CharState { idle,run,attack,jumping,death};
    class Hero : IGameObject, ITransform,ICombat
    {
        public const int height = 60;
        public const int Width = 50;

        
        HeroAnimations heroanimations;
        List<Texture2D> herotexture;
        List<List<Animatie>> animations;
        public LoopRichting richting { get ; set; }
        public CharState status { get; set; }

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


        public Rectangle Attackbox { get; set; }
        public bool Attacklock { get; set ; }
        public int Health { get ; set ; }
        public int Damage { get; set ; }

        public Hero(List<Texture2D> textures,CollisionDetection objects)
        {
            
            //basic information of entity
            Position = new Vector2(400, 400);
            VerticalMovement = new Vector2(0, 0);// X: verticalmovement => 1 = ja          0= nee    Y: current jump speed
            HorizontalMovement = new Vector2(0, 4);// X: richting -1 => links 0=> stil 1=> rechts    Y: Current movespeed
            status = CharState.idle;
            richting = LoopRichting.rechts;
            herotexture = textures;
            this.Attackbox = new Rectangle(0, 0, 60, 60);
            Attacklock = false;
            Health = 100;
            Damage = 20;

            //animations
            animations = new List<List<Animatie>>();
            heroanimations = new HeroAnimations();
            animations.Add(heroanimations.Idle());
            animations.Add(heroanimations.Run());
            animations.Add(heroanimations.Attack());
            animations.Add(heroanimations.Jump());
            animations.Add(heroanimations.Death());

            //movement and input
            this.inputreader = new KeyboardReader(this);
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
            UpdateAnimations(gametime);
            if (this.status != CharState.death)
            {
                StatePicker();

                MoveHorizontal(inputreader.ReadLeftRight());
                MoveVertical();
                updateAttackbox();
                inputreader.ReadAttack();
                _CollisionRectangle.X = (int)Position.X;
                _CollisionRectangle.Y = (int)Position.Y;

            }
            

        }
        private void updateAttackbox()
        {

            if (this.richting == LoopRichting.rechts)
            {
                this.Attackbox = new Rectangle((int)this.Position.X + this.CollisionRectangle.Width, (int)this.Position.Y, (int)this.Attackbox.Width, (int)this.Attackbox.Height);
            }
            else
            {
                this.Attackbox = new Rectangle((int)this.Position.X - (int)this.Attackbox.Width, (int)this.Position.Y, (int)this.Attackbox.Width, (int)this.Attackbox.Height);
            }
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
            inputreader.IsJumping();
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

        public void TakeDamage(int dmg)
        {
            this.Health -= dmg;
            if (Health < 0)
            {
                Debug.Write("player death");
                this.status = CharState.death;
            }

        }
    }
}
