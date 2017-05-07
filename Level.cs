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
            GenerateRoom(0, 0, Width, Height);
            //map[4, 2] = new Door(Door.Sprites.Horizontal, false);
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

        public void Interact(int Xposition, int Yposition)
        {
            map[Yposition, Xposition].ExecuteBehaviour();
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
            map[Yposition, Xposition] = new Wall(Wall.Sprites.TopLeft);
            map[Yposition, Xposition + Width - 1] = new Wall(Wall.Sprites.TopRight);
            map[Yposition + Height - 1, Xposition] = new Wall(Wall.Sprites.BotLeft);
            map[Yposition + Height - 1, Xposition + Width - 1] = new Wall(Wall.Sprites.BotRight);
            for (int i = Yposition + 1; i < Yposition + Width - 1; ++i)
            {
                map[i, Xposition] = new Wall(Wall.Sprites.Vertical);
                map[i, Xposition + Width - 1] = new Wall(Wall.Sprites.Vertical);
            }
            for (int j = Xposition + 1; j < Xposition + Height - 1; ++j)
            {
                map[Yposition, j] = new Wall(Wall.Sprites.Horizontal);
                map[Yposition + Height - 1, j] = new Wall(Wall.Sprites.Horizontal);
            }
        }

        #region Fields

        private int width, height;
        private Tile[,] map;
        private List<Character> characters;

        #endregion
    }
}