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

        #endregion

        public void Update()
        {
            Draw();
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

        private void Draw()
        {
            // temporary fix, will replace with camera
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    map[i, j].Draw();
                Console.Write('\n');
            }
        }

        #region Fields

        private int width, height;
        private Tile[,] map;
        private List<Character> characters;

        #endregion
    }
}
