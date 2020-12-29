using GameDevProject.Animation;
using GameDevProject.Animation.AnimationCreators;
using GameDevProject.Command;
using GameDevProject.Detections;
using GameDevProject.Input;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GameDevProject.Entities
{
    abstract class Enemy : IGameObject, ITransform,ICombat
    {

        List<Texture2D> texture;
        protected List<List<Animatie>> animations;//animations zal gegeven worden door de overerving
        public CharState status { get; set; }
        public LoopRichting richting { get; set; }
        private AIReader inputreader;
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
        public int Health { get; set; }
        public int Damage { get; set; }

        public Enemy(List<Texture2D> textures, CollisionDetection objects, AIReader AiInputReader)
        {
            
            //basic information of entity
            Position = new Vector2(100, 100);
            VerticalMovement = new Vector2(0, 0);// X: verticalmovement => 1 = ja          0= nee    Y: current jump speed
            HorizontalMovement = new Vector2(0, 2);// X: richting -1 => links 0=> stil 1=> rechts    Y: Current movespeed
            status = CharState.idle;
            richting = LoopRichting.links;
            texture = textures;
            this.Attackbox = new Rectangle(0, 0, 60, 60);
            Attacklock = false;
            Health = 100;
            Damage = 5;

            //animations zal gegeven worden door de overerving



            //movement and input
            this.inputreader = AiInputReader;
            this.inputreader.SetEntity(this);
            this.movecommand = new MoveCommand(objects);
            

        }
        public void Spawn(Vector2 pos)
        {
            this.Position = pos;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture[(int)richting], Position, animations[(int)status][(int)richting].CurrentFrame.SourceRectangle, Color.White);

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

        private void UpdateAnimations(GameTime gametime)
        {
            animations[(int)status][(int)richting].update(gametime, this);
        }
        private void StatePicker()
        {
            if (status != CharState.death)
            {
                if (status != CharState.attack)
                {

                    if (this.VerticalMovement.X == 1)
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
                //Debug.Write("enemy death");
                this.status = CharState.death;
            }
        }
    }
}
