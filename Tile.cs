using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Tile
    {
        protected Tile(char Sprite, ConsoleColor Color, bool IsSolid)
        {
            _sprite = Sprite;
            _color = Color;
            _isSolid = IsSolid;
        }

        #region Properties

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

        public char Sprite
        {
            get { return _sprite; }
            protected set { _sprite = value; }
        }

        #endregion

        public static Tile Empty()
        {
            return new Tile(' ', Console.ForegroundColor, false);
        }

        public virtual void ExecuteBehaviour() { }

        public void Draw()
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.Write(_sprite);
            Console.ForegroundColor = aux;
        }

        #region Fields

        private char _sprite;
        private ConsoleColor _color;
        private bool _isSolid;

        #endregion
    }
}
