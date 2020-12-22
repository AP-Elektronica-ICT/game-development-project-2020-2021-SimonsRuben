using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using GameDevProject.Detections;

namespace GameDevProject.Input
{
    class AIReader : IinputReader
    {
        private ITransform Entity;

        private ITransform target;

        public AIReader( ITransform targettransform)
        {
            this.target = targettransform;
        }
        public void SetEntity(ITransform Entitytransform)
        {
            this.Entity = Entitytransform;
        }
        public void IsJumping()
        {


            if ((target.Position.Y < Entity.Position.Y -10) && Entity.status != CharState.jumping && Entity.VerticalMovement.X == 0)
            {
                Entity.VerticalMovement = new Vector2(1, -12f);
            }
        }

        public void ReadAttack()
        {
            
            if (this.Entity.status != CharState.attack && CollisionDetection.CheckCollision(Entity.Attackbox, target.CollisionRectangle))
            {
                this.Entity.status = CharState.attack;
                //Debug.WriteLine("hit");
            }


        }

        public Vector2 ReadLeftRight()
        {
            Vector2 direction = new Vector2();
            if (this.Entity.Position.X >= this.target.Position.X + 10)
            {
                //Debug.WriteLine("entity move left");
                direction = new Vector2(-1, 0);

            }
            else if (this.Entity.Position.X <= this.target.Position.X - 10)
            {
                //Debug.WriteLine("entity move right");
                direction = new Vector2(1, 0);
            }



            return direction;
        }
    }
}
