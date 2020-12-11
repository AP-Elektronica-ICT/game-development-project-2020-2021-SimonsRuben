using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TiledSharp;
using System.Diagnostics;
using GameDevProject.Detections;

namespace GameDevProject.World
{
    class Wereld
    {
        List<Room> world = new List<Room>();

        int currroom = 0;

        private Room _activeRoom;

        public Room ActiveRoom
        {
            get 
            {
                _activeRoom = world[currroom];
                return _activeRoom; 
            }
            set 
            { 
                _activeRoom = value; 
            }
        }


        public Wereld(List<Room> w)
        {
            this.world = w;

        }

        public void Update(Hero hero)
        {
            int PickedDoor = CheckDoors(hero);
            if (PickedDoor != -1)
            {
                int Spawn = 0;
                if (PickedDoor / 2 < 1)
                {
                    Spawn = PickedDoor + 2;
                }
                else if (PickedDoor /2 >= 1)
                {
                    Spawn = PickedDoor - 2;
                }
                Debug.WriteLine((side)PickedDoor);
                currroom++;
                hero.Spawn(ActiveRoom.SpawnAreas[Spawn]);
            }
            
        }
        private int CheckDoors(Hero hero)
        {
            for (int i = 0; i < ActiveRoom.Doors.Count; i++)
            {
                if (CollisionDetection.CheckCollision(hero.CollisionRectangle, ActiveRoom.Doors[i]))
                {
                    return i;
                }
            }

            return -1;
        }



    }
}
