using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Tile
    {
        protected Tile(char Sprite, bool IsSolid)
        {
            _sprite = Sprite;
            _isSolid = IsSolid;
        }

        public static Tile Empty()
        {
            return new Tile(' ', false);
        }

        public bool IsSolid
        {
            get { return _isSolid; }
            protected set { _isSolid = value; }
        }

        public ConsoleColor Color
        {
            get { return _color; }
            protected set { _color = value; }
        }

        protected virtual void ExecuteBehaviour() { }

        public void Draw()
        {
            Console.Write(_sprite);
        }

        private char _sprite = ' ';
        private bool _isSolid;
        private ConsoleColor _color;
    }
}
