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
    class Spearman : Enemy
    {
        public const int height = 65;
        public const int Width = 65;
        public static List<Texture2D> textures;
        public Spearman( CollisionDetection objects , AIReader AiInputReader) : base(textures,objects,AiInputReader) 
        {
            //animations 
            AnimationCreator creator = new AnimationCreator();
            animations = creator.GetSpearmanAnimation();
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, Spearman.Width - 20, Spearman.height);//-20 offset door de speer die hij vastheeft
        }
    }
}
