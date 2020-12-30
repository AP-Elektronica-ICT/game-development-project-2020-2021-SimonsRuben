using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.World
{
    public enum room { StartRoom, CentralRoom, BottemRoom, TopRoom, EndingRoom }
    class LevelPicker : IGameObject
    {
        List<Room> PossibleRooms = new List<Room>();
        private int levelnumber;
        List<Wereld> Levels;
        private Hero hero;
        public LevelPicker(List<Room> w, Hero h)
        {
            this.hero = h;
            this.Levels = new List<Wereld>();
            this.levelnumber = 0;
            this.PossibleRooms = w;
            this.Levels.Add(new Wereld(level1(), new Vector2(0, 1),new  Vector2(2,1)));
            this.Levels.Add(new Wereld(level2(), new Vector2(0, 1), new Vector2(2, 1)));

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

        private Room[,] level1()
        {
            Room [,] temp = new Room[,] {
                { null,PossibleRooms[(int)room.TopRoom],null },
                { PossibleRooms[(int)room.StartRoom],PossibleRooms[(int)room.CentralRoom],PossibleRooms[(int)room.EndingRoom]  },
                { null,PossibleRooms[(int)room.BottemRoom],null } };
            return temp;

        }
        private Room[,] level2()
        {
            Room[,] temp = new Room[,] {
                {PossibleRooms[(int)room.TopRoom],null,null },
                { PossibleRooms[(int)room.CentralRoom],PossibleRooms[(int)room.EndingRoom] ,PossibleRooms[(int)room.EndingRoom] },
                { PossibleRooms[(int)room.BottemRoom],null,null } };
            return temp;

        }



    }
}
