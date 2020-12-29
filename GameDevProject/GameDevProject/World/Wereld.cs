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
        List<Room> Rooms = new List<Room>();

        private Vector2 cords;

        private Room[,] world;

        private Room _activeRoom;

        public Room ActiveRoom
        {
            get 
            {
                _activeRoom = world[(int)cords.Y,(int)cords.X];// Y is welke Rij het is en X is de Colom
                return _activeRoom; 
            }
            set 
            { 
                _activeRoom = value; 
            }
        }


        public Wereld(List<Room> w)
        {
            this.Rooms = w;
            world = new Room[,] { 
                { null,Rooms[3],null },
                { Rooms[0],Rooms[1],Rooms[4]  },
                { null,Rooms[2],null } };


            cords = new Vector2(0, 1);//
        }

        public void Update(Hero hero,GameTime gameTime)
        {
            UpdateRoom(hero);
            this.ActiveRoom.Update(gameTime);


        }

        private void UpdateRoom(Hero hero)
        {
            int PickedDoor = CheckDoors(hero);
            if (PickedDoor != -1)
            {
                int Spawn = 0;
                if (PickedDoor / 2 < 1)
                {
                    Spawn = PickedDoor + 2;
                }
                else if (PickedDoor / 2 >= 1)
                {
                    Spawn = PickedDoor - 2;
                }

                int NextRoom = 1;
                if (PickedDoor % 3 == 0)
                {
                    NextRoom = -1;
                }

                if (PickedDoor % 2 == 0)
                {
                    cords.Y += NextRoom;
                }
                else
                {
                    cords.X += NextRoom;
                }
                //Debug.WriteLine((side)PickedDoor);
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
