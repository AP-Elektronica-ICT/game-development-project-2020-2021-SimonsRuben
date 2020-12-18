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
    class Spearman : ITransform,IGameObject,IEntity
    {
        public const int height = 69;
        public const int Width = 65;

  
        SpearManAnimations spearmanAnimations;
        List<Texture2D> SpearmanTexture;
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




        public Spearman(List<Texture2D> textures, CollisionDetection objects)
        {

            Position = new Vector2(100, 100);
            CollisionRectangle = new Rectangle((int)Position.X,(int)Position.Y, Spearman.Width, Spearman.height);

            status = CharState.idle;
            richting = LoopRichting.links;
            SpearmanTexture = textures;
            animations = new List<List<Animatie>>();
            spearmanAnimations = new SpearManAnimations();
            animations.Add(spearmanAnimations.Idle());
            animations.Add(spearmanAnimations.Run());
            animations.Add(spearmanAnimations.Attack());
            animations.Add(spearmanAnimations.Jump());

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
            UpdateAnimations(gametime);
            _CollisionRectangle.X = (int)Position.X;
            _CollisionRectangle.Y = (int)Position.Y;
        }

        private void UpdateAnimations(GameTime gametime)
        {
            animations[(int)status][(int)richting].update(gametime, this);
        }
    }
}
