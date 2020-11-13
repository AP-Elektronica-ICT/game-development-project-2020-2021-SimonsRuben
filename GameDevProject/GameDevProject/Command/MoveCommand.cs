using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Command
{
    class MoveCommand :IGameCommand
    {
        

        public void ExecuteHorizontal(ITransform transform,Vector2 direction)
        {
            direction *= transform.HorizontalMovement.Y;
            transform.Position += direction;
        }

        public void ExecuteVertical(ITransform transform, float ground)
        {
            //Bron voor de jump code: http://flatformer.blogspot.com/2010/02/making-character-jump-in-xnac-basic.html
            

            transform.Position += new Vector2(0, transform.VerticalMovement.Y);//Making it go up
            transform.VerticalMovement = new Vector2(transform.VerticalMovement.X, transform.VerticalMovement.Y + 0.2f);
            if (transform.Position.Y >= ground)
            //If it's farther than ground
            {
                transform.Position = new Vector2(transform.Position.X, ground);//Then set it on
                Hero.status = CharState.run;
            }
        }
    }
}
