using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TopDownGame
{
    class World
    {
        public World(int Width, int Height)
        {
            width = Width;
            height = Height;
            Generate();
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Point DrawOrigin
        {
            get { return drawOrigin; }
            set { drawOrigin = value; }
        }

        public List<Character> Characters
        {
            get { return characters; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public void Update()
        {
            // execute world logic
            Draw();
            foreach(Character c in characters)
                c.Update();
        }

        public bool CheckCollision(Point PointOfContact)
        {
            if (map[PointOfContact.Y, PointOfContact.X].IsSolid)
                return true;
            return false;
        }

        public bool CheckCollision(int Xcontact, int Ycontact)
        {
            if (map[Ycontact, Xcontact].IsSolid)
                return true;
            return false;
        }

        public void Interact(Point PointOfContact, object[] args = null)
        {
            map[PointOfContact.Y, PointOfContact.X].ExecuteBehaviour(args);
        }

        private void Generate()
        {
            map = new Tile[height, width];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    map[y, x] = Tile.Empty();

            GenerateRoom(2, 2, 30, 11);
            GenerateRoom(38, 3, 10, 10);
            GenerateRoom(3, 17, 27, 6);
            GenerateHorizontalHallway(31, 8, 8, true);
            GenerateVerticalHallway(8, 12, 6, false);

            characters = new List<Character>();
        }

        private void GenerateRoom(int Xorigin, int Yorigin, int width, int height)
        {
            map[Yorigin, Xorigin] = new Wall(Wall.Sprite.TopLeft);
            map[Yorigin, Xorigin + width - 1] = new Wall(Wall.Sprite.TopRight);
            map[Yorigin + height - 1, Xorigin + width - 1] = new Wall(Wall.Sprite.BotRight);
            map[Yorigin + height - 1, Xorigin] = new Wall(Wall.Sprite.BotLeft);
            for (int x = Xorigin + 1; x < Xorigin + width - 1; ++x)
            {
                map[Yorigin, x] = new Wall(Wall.Sprite.Horizontal);
                map[Yorigin + height - 1, x] = new Wall(Wall.Sprite.Horizontal);
            }
            for (int y = Yorigin + 1; y < Yorigin + height - 1; ++y)
            {
                map[y, Xorigin] = new Wall(Wall.Sprite.Vertical);
                map[y, Xorigin + width - 1] = new Wall(Wall.Sprite.Vertical);
            }
        }

        private void GenerateHorizontalHallway(int Xorigin, int Yorigin, int Length, bool HasDoors)
        {
            for (int x = Xorigin + 1; x < Xorigin + Length; ++x)
            {
                map[Yorigin + 1, x] = new Wall(Wall.Sprite.Horizontal);
                map[Yorigin - 1, x] = new Wall(Wall.Sprite.Horizontal);
            }
            if(HasDoors)
            {
                map[Yorigin + 1, Xorigin] = new Wall(Wall.Sprite.InterRight);
                map[Yorigin - 1, Xorigin] = new Wall(Wall.Sprite.InterRight);
                map[Yorigin, Xorigin] = new Door(Door.Sprite.Vertical);
                map[Yorigin + 1, Xorigin + Length - 1] = new Wall(Wall.Sprite.InterLeft);
                map[Yorigin - 1, Xorigin + Length - 1] = new Wall(Wall.Sprite.InterLeft);
                map[Yorigin, Xorigin + Length - 1] = new Door(Door.Sprite.Vertical);
            }
            else
            {
                map[Yorigin + 1, Xorigin] = new Wall(Wall.Sprite.TopLeft);
                map[Yorigin - 1, Xorigin] = new Wall(Wall.Sprite.BotLeft);
                map[Yorigin, Xorigin] = Tile.Empty();
                map[Yorigin + 1, Xorigin + Length - 1] = new Wall(Wall.Sprite.TopRight);
                map[Yorigin - 1, Xorigin + Length - 1] = new Wall(Wall.Sprite.BotRight);
                map[Yorigin, Xorigin + Length - 1] = Tile.Empty();
            }
        }

        private void GenerateVerticalHallway(int Xorigin, int Yorigin, int Length, bool HasDoors)
        {
            for (int y = Yorigin + 1; y < Yorigin + Length; ++y)
            {
                map[y, Xorigin + 1] = new Wall(Wall.Sprite.Vertical);
                map[y, Xorigin - 1] = new Wall(Wall.Sprite.Vertical);
            }
            if (HasDoors)
            {
                map[Yorigin, Xorigin + 1] = new Wall(Wall.Sprite.InterBot);
                map[Yorigin, Xorigin - 1] = new Wall(Wall.Sprite.InterBot);
                map[Yorigin, Xorigin] = new Door(Door.Sprite.Horizontal);
                map[Yorigin + Length - 1, Xorigin + 1] = new Wall(Wall.Sprite.InterTop);
                map[Yorigin + Length - 1, Xorigin - 1] = new Wall(Wall.Sprite.InterTop);
                map[Yorigin + Length - 1, Xorigin] = new Door(Door.Sprite.Horizontal);
            }
            else
            {
                map[Yorigin, Xorigin + 1] = new Wall(Wall.Sprite.TopLeft);
                map[Yorigin, Xorigin - 1] = new Wall(Wall.Sprite.TopRight);
                map[Yorigin, Xorigin] = Tile.Empty();
                map[Yorigin + Length - 1, Xorigin + 1] = new Wall(Wall.Sprite.BotLeft);
                map[Yorigin + Length - 1, Xorigin - 1] = new Wall(Wall.Sprite.BotRight);
                map[Yorigin + Length - 1, Xorigin] = Tile.Empty();
            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(drawOrigin.X, drawOrigin.Y);
            for (int y = 0; y < height; ++y)
            {
                Console.SetCursorPosition(drawOrigin.X, drawOrigin.Y + y);
                for (int x = 0; x < width; ++x)
                    Console.Write(map[y, x].Look());
                Console.Write('\n');
            }
        }

        private Point drawOrigin;
        private int width, height;
        private Tile[,] map;
        private Player player;
        private List<Character> characters;
    }
}
