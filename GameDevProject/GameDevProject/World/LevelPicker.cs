using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using GameDevProject.Detections;

namespace GameDevProject.World
{
    public enum room { Empty = -1,StartRoom, CentralRoom, BottemRoom, TopRoom, EndingRoom }
    class LevelPicker : IGameObject
    {
        List<Room> PossibleRooms = new List<Room>();
        private int levelnumber;
        List<Wereld> Levels;
        private Hero hero;
        private CollisionDetection coldetect;

        private room[,] level1 = new room[,]
        {
                    {room.Empty,room.TopRoom,room.Empty },
                    {room.StartRoom,room.CentralRoom,room.EndingRoom },
                    {room.Empty,room.BottemRoom,room.Empty }
        };

        private room[,] level2 = new room[,]
        {
                    {room.TopRoom,room.Empty,room.Empty },
                    {room.CentralRoom,room.EndingRoom,room.EndingRoom },
                    {room.BottemRoom,room.EndingRoom,room.Empty }
        };
        public LevelPicker(List<Room> w, Hero h,CollisionDetection collisionDetect)
        {
            this.hero = h;
            this.Levels = new List<Wereld>();
            this.levelnumber = 0;
            this.PossibleRooms = w;
            this.coldetect = collisionDetect;
            this.Levels.Add(new Wereld(CreateWorld(level1), new Vector2(0, 1),new  Vector2(3,1)));
            this.Levels.Add(new Wereld(CreateWorld(level2), new Vector2(0, 1), new Vector2(3, 1)));
        }
        public void SetLevel(int levelinput)
        {
            this.levelnumber = levelinput - 1;
            hero.Spawn(Levels[levelnumber].ActiveRoom.GetSpawn());
        }
        public int GetAmountOfLevels()
        {
            return this.Levels.Count;
        }
        public bool Done()
        {
            if (Levels[levelnumber].completed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Levels[levelnumber].Draw(spritebatch);
        }

        public void Update(GameTime gametime)
        {
            Levels[levelnumber].Update(hero, gametime);
        }
        public Wereld GetActiveWereld()
        {
            return Levels[levelnumber];
        }

       

        private Room[,] CreateWorld(room[,] input)
        {              
            Room[,] temp = new Room[input.GetLength(0), input.GetLength(1)];
            for (int x = 0; x < input.GetLength(0); x++)
            {
                for (int y = 0; y < input.GetLength(1); y++)
                {
                    if (input[x,y] == room.Empty)
                    {
                        temp[x, y] = null;
                    }
                    else
                    {
                        temp[x, y] = new Room(PossibleRooms[(int)input[x, y]], coldetect, hero);
                    }
                }
            }
            return temp;
        }



    }
}
