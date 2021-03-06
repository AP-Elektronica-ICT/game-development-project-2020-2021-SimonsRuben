﻿using GameDevProject.Detections;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void ExecuteVertical(ITransform transform)
        {
            
            //Bron voor de jump code: http://flatformer.blogspot.com/2010/02/making-character-jump-in-xnac-basic.html

            // berekenen van de toekomstige positie
            Rectangle future = new Rectangle((int)(transform.Position.X), (int)(transform.Position.Y + transform.VerticalMovement.Y), transform.CollisionRectangle.Width, transform.CollisionRectangle.Height);
            if (!wallsandobjects.checkwallsandplatforms(future)&& transform.VerticalMovement.X ==1)
            {
                transform.Position += new Vector2(0, transform.VerticalMovement.Y);//Making it go up
                transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, transform.VerticalMovement.Y + 0.4f);
                jumplock = false;

                //gewoone jump zonder iets te raken
            }
            else if (transform.VerticalMovement.X == 0 && !wallsandobjects.checkwallsandplatforms(future))
            {
                transform.VerticalMovement = new Vector2(1, 0f);
                jumplock = false;

                // vanaf er geen grond meer is begin te vallen (gravity)
            }
            else if (wallsandobjects.checkhead(future)&& transform.VerticalMovement.X == 1 && transform.VerticalMovement.Y < 0)
            {
                transform.Position -= new Vector2(0, transform.VerticalMovement.Y);
                transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, 0f);

                //tijdens het jumpen vanaf er iets het hoofd raak begin te vallen
            }
            else if(wallsandobjects.checkwallsandplatforms(future) && transform.VerticalMovement.X ==1 )
            {

                transform.Position = new Vector2(transform.Position.X, (float)(wallsandobjects.SearchTopCollider(future)-transform.CollisionRectangle.Height));
                transform.VerticalMovement = new Vector2(0, transform.VerticalMovement.Y);

                //er wordt gecheckt op het smooth vallen van de player
                // als de player valt en de volgende Y cords komen in een blok dan worden de Y cords gezet naar de blok top en de hoogte van de player wordt eraf gedaan
                // zo maak je dat hij mooi valt op de blok en verder kan doen

            }
            else if (!jumplock)
            {
                jumplock = true;
            }
        }

    }
}
