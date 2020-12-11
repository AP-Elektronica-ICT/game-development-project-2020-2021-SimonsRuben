using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Detections
{
    class CollisionDetection
    {
        public List<Rectangle> walls;

        public CollisionDetection(List<Rectangle> objects)
        {
            this.walls = objects;
        }


        public bool checkwallsandplatforms(Rectangle character)
        {
            foreach (Rectangle item in walls)
            {
                if (CheckCollision(character,item))
                {
                    //Debug.WriteLine("COLLISION");
                    return true;
                }
                
            }
            return false;
        }

        public static bool CheckCollision(Rectangle entity1, Rectangle entity2)
        {
            if (entity1.Intersects(entity2))
            {
                return true;
            }
            return false;
        }
        public bool checkhead(Rectangle character)
        {
            foreach (Rectangle item in walls)
            {
                if (character.Top < item.Bottom && character.Top > item.Top)
                {
                    //Debug.WriteLine("HEAD");
                    return true;
                }

            }
            return false;
        }
        public int SearchTopCollider(Rectangle character)
        {
            foreach (Rectangle item in walls)
            {
                if (CheckCollision(character, item))
                {
                    //Debug.WriteLine("COLLISION");
                    Debug.WriteLine(item.Top);
                    return item.Top;
                }

            }
            return 0;
        }
    }
}
