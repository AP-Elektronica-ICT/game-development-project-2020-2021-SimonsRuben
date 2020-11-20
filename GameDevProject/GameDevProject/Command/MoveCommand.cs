using GameDevProject.Detections;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Command
{
    class MoveCommand :IGameCommand
    {
        private CollisionDetection wallsandobjects;
        private bool jumplock;
        public MoveCommand(CollisionDetection colldetect)
        {
            this.wallsandobjects = colldetect;
            jumplock = false;

        }
        

        public void ExecuteHorizontal(ITransform transform,Vector2 direction)
        {
            direction *= transform.HorizontalMovement.Y;
            Rectangle future = new Rectangle((int)(transform.Position.X + direction.X), (int)(transform.Position.Y + direction.Y), transform.CollisionRectangle.Width, transform.CollisionRectangle.Height);
            if (!wallsandobjects.checkwallsandplatforms(future))
            {
                
                transform.Position += direction;
            }
            
            
        }

        public void ExecuteVertical(ITransform transform, float ground)
        {
            //Bron voor de jump code: http://flatformer.blogspot.com/2010/02/making-character-jump-in-xnac-basic.html
            Rectangle future = new Rectangle((int)(transform.Position.X), (int)(transform.Position.Y + transform.VerticalMovement.Y), transform.CollisionRectangle.Width, transform.CollisionRectangle.Height);
            if (!wallsandobjects.checkwallsandplatforms(future)&& Hero.status == CharState.jumping)
            {
                transform.Position += new Vector2(0, transform.VerticalMovement.Y);//Making it go up
                transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, transform.VerticalMovement.Y + 0.4f);
                jumplock = false;
                //gewoone jump zonder iets te raken
            }
            else if (Hero.status !=CharState.jumping && !wallsandobjects.checkwallsandplatforms(future))
            {
                Hero.status = CharState.jumping;
                transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, 0f);
                jumplock = false;
                // vanaf er geen grond meer is begin te vallen
            }
            else if (wallsandobjects.checkhead(future)&& Hero.status == CharState.jumping && transform.VerticalMovement.Y < 0)
            {
                transform.Position -= new Vector2(0, transform.VerticalMovement.Y);
                transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, 0f);
                //tijdens het jumpen vanaf er iets het hoofd raak begin te vallen
            }

            else if (!jumplock)
            {
                Hero.status = CharState.idle;
                jumplock = true;
            }
            /*

            if (transform.Position.Y >= ground)
            //If it's farther than ground
            {
                transform.Position = new Vector2(transform.Position.X, ground);//Then set it on
                Hero.status = CharState.run;
            }*/
        }

    }
}
