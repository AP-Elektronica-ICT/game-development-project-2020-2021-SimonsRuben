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

namespace GameDevProject.Entities
{
    class Spearman :  IGameObject,ITransform
    {
        public const int height = 65;
        public const int Width = 65;

  
        SpearManAnimations spearmanAnimations;
        List<Texture2D> SpearmanTexture;
        List<List<Animatie>> animations;
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

        public Vector2 AttackRange { get ; set ; }

        private Rectangle _CollisionRectangle;

        


        
        public Spearman(List<Texture2D> textures, CollisionDetection objects , AIReader AiInputReader)
        {
            //basic information of entity
            Position = new Vector2(100, 100);
            VerticalMovement = new Vector2(0, 0);// X: verticalmovement => 1 = ja          0= nee    Y: current jump speed
            HorizontalMovement = new Vector2(0, 2);// X: richting -1 => links 0=> stil 1=> rechts    Y: Current movespeed
            status = CharState.idle;
            richting = LoopRichting.links;
            SpearmanTexture = textures;
            this.AttackRange = new Vector2(60, 60);

            //animations
            animations = new List<List<Animatie>>();
            spearmanAnimations = new SpearManAnimations();
            animations.Add(spearmanAnimations.Idle());
            animations.Add(spearmanAnimations.Run());
            animations.Add(spearmanAnimations.Attack());
            animations.Add(spearmanAnimations.Jump());

            //movement and input
            this.inputreader = AiInputReader;
            this.inputreader.SetEntity(this);
            this.movecommand = new MoveCommand(objects);
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Spearman.Width -20, Spearman.height);//-20 offset


        }
        





        public void Spawn(Vector2 pos)
        {
            this.Position = pos;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(SpearmanTexture[(int)richting], Position, animations[(int)status][(int)richting].CurrentFrame.SourceRectangle, Color.White);

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

        private void UpdateAnimations(GameTime gametime)
        {
            animations[(int)status][(int)richting].update(gametime, this);
        }
        private void StatePicker()
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
    }
}
