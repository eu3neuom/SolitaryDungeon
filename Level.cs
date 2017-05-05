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

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
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
        }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    map[i, j].Draw();
                Console.Write('\n');
            }
        }

        private int width, height;
        private Tile[,] map;
    }
}
