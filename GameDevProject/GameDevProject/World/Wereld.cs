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
    public enum room { StartRoom, CentralRoom, BottemRoom, TopRoom, EndingRoom }
    class Wereld
    {
        List<Room> Rooms = new List<Room>();

        private Vector2 cords;
        private int level;


        private List<Room[,]> World;
        private Room _activeRoom;

        public Room ActiveRoom
        {
            get 
            {
                _activeRoom = World[level][(int)cords.Y,(int)cords.X];// Y is welke Rij het is en X is de Colom
                return _activeRoom; 
            }
            set 
            { 
                _activeRoom = value; 
            }
        }


        public Wereld(List<Room> w)
        {
            level = 0;
            World = new List<Room[,]>();
            this.Rooms = w;
            World.Add(new Room[,] { 
                { null,Rooms[(int)room.TopRoom],null },
                { Rooms[(int)room.StartRoom],Rooms[(int)room.CentralRoom],Rooms[(int)room.EndingRoom]  },
                { null,Rooms[(int)room.BottemRoom],null } });

            World.Add(new Room[,] {
                { Rooms[(int)room.TopRoom],null ,null },
                { Rooms[(int)room.CentralRoom] , Rooms[(int)room.EndingRoom] , Rooms[(int)room.EndingRoom] },
                {  Rooms[(int)room.BottemRoom],null ,null} });


            cords = new Vector2(0, 1);//
        }

        public void Update(Hero hero,GameTime gameTime)
        {
            ProgressRoom(hero);
            this.ActiveRoom.Update(gameTime);


        }
        private void ProgressRoom(Hero hero)
        {
            if (this.ActiveRoom.RoomCleared())
            {
                UpdateRoom(hero);
            }
            
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
                    if (cords.Y + NextRoom >= 0  && cords.Y + NextRoom < World[level].GetLength(0))
                    {
                        cords.Y += NextRoom;
                        hero.Spawn(ActiveRoom.SpawnAreas[Spawn]);
                    }
                    
                }
                else
                {
                    if (cords.X + NextRoom >= 0 && cords.X + NextRoom < World[level].GetLength(1))
                    {
                        cords.X += NextRoom;
                        hero.Spawn(ActiveRoom.SpawnAreas[Spawn]);
                    }
                    
                }

                //Debug.WriteLine((side)PickedDoor);
                
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
