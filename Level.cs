using System.Collections.Generic;

namespace SolitaryDungeon
{
    class Level
    {
        public Level(int Width, int Height)
        {
            _width = Width;
            _height = Height;
            InitializeMap();
            GenerateRoom(0, 0, Width, Height);
            _characters = new List<Character>();
        }

        #region Properties

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Tile[,] Map
        {
            get { return _map; }
        }

        public List<Character> Characters
        {
            get { return _characters; }
        }

        public Player Player
        {
            get { return (Player)_characters[0]; }
        }

        #endregion

        public void Update()
        {
            for (int i = 1; i < _characters.Count; ++i)
                _characters[i].Update();
        }

        public bool CheckCollision(int Xposition, int Yposition)
        {
            return _map[Yposition, Xposition].IsSolid;
        }

        public void Interact(int Xposition, int Yposition)
        {
            _map[Yposition, Xposition].ExecuteBehaviour();
        }

        private void InitializeMap()
        {
            _map = new Tile[_height, _width];
            for (int i = 0; i < _height; ++i)
                for (int j = 0; j < _width; ++j)
                    _map[i, j] = Tile.Empty();
        }

        private void GenerateRoom(int Xposition, int Yposition, int Width = 5, int Height = 5)
        {
            _map[Yposition, Xposition] = new Wall(Wall.Type.TopLeft);
            _map[Yposition, Xposition + Width - 1] = new Wall(Wall.Type.TopRight);
            _map[Yposition + Height - 1, Xposition] = new Wall(Wall.Type.BotLeft);
            _map[Yposition + Height - 1, Xposition + Width - 1] = new Wall(Wall.Type.BotRight);
            for (int i = Yposition + 1; i < Yposition + Width - 1; ++i)
            {
                _map[i, Xposition] = new Wall(Wall.Type.Vertical);
                _map[i, Xposition + Width - 1] = new Wall(Wall.Type.Vertical);
            }
            for (int j = Xposition + 1; j < Xposition + Height - 1; ++j)
            {
                _map[Yposition, j] = new Wall(Wall.Type.Horizontal);
                _map[Yposition + Height - 1, j] = new Wall(Wall.Type.Horizontal);
            }
        }

        #region Fields

        private int _width, _height;
        private Tile[,] _map;
        private List<Character> _characters;

        #endregion
    }
}