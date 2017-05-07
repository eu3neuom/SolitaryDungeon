using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Level
    {
        public Level(int Width, int Height)
        {
            width = Width;
            height = Height;
            InitializeMap();
            GenerateRoom(0, 0);
            characters = new List<Character>();
        }

        #region Properties

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Tile[,] Map
        {
            get { return map; }
        }

        public List<Character> Characters
        {
            get { return characters; }
        }

        public Player Player
        {
            get { return (Player)characters[0]; }
        }

        #endregion

        public void Update()
        {
            for (int i = 1; i < characters.Count; ++i)
                characters[i].Update();
        }

        public bool CheckCollision(int Xposition, int Yposition)
        {
            return map[Yposition, Xposition].IsSolid;
        }

        private void InitializeMap()
        {
            map = new Tile[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    map[i, j] = Tile.Empty();
        }

        private void GenerateRoom(int Xposition, int Yposition, int Width = 5, int Height = 5)
        {
            map[Yposition, Xposition] = new Wall(Wall.Sprite.TopLeft);
            map[Yposition, Xposition + Width] = new Wall(Wall.Sprite.TopRight);
            map[Yposition + Height, Xposition] = new Wall(Wall.Sprite.BotLeft);
            map[Yposition + Height, Xposition + Width] = new Wall(Wall.Sprite.BotRight);
            for (int i = Yposition + 1; i < Yposition + Width; ++i)
            {
                map[i, Xposition] = new Wall(Wall.Sprite.Vertical);
                map[i, Xposition + Width] = new Wall(Wall.Sprite.Vertical);
            }
            for (int j = Xposition + 1; j < Xposition + Height; ++j)
            {
                map[Yposition, j] = new Wall(Wall.Sprite.Horizontal);
                map[Yposition + Height, j] = new Wall(Wall.Sprite.Horizontal);
            }
        }

        #region Fields

        private int width, height;
        private Tile[,] map;
        private List<Character> characters;

        #endregion
    }
}
