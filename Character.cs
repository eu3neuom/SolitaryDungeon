using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    abstract class Character
    {
        protected Character(int Xposition, int Yposition, ConsoleColor Color)
        {
            _xPos = Xposition;
            _yPos = Yposition;
            _oxPos = Xposition;
            _oyPos = Yposition;
            _color = Color;
        }

        #region Properties

        public int Xpos
        {
            get { return _xPos; }
            protected set { _xPos = value;}
        }

        public int Ypos
        {
            get { return _yPos; }
            protected set { _yPos = value; }
        }

        public int Xorient
        {
            get { return _oxPos; }
            protected set { _oxPos = value; }
        }

        public int Yorient
        {
            get { return _oyPos; }
            protected set { _oyPos = value; }
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

        public void Update()
        {
            Clear();
            ExecuteBehaviour();
            Draw();
        }

        protected abstract void ExecuteBehaviour();

        private void Draw()
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_xPos, _yPos);
            Console.Write(_sprite);
            Console.ForegroundColor = aux;
        }

        private void Clear()
        {
            Console.SetCursorPosition(_xPos, _yPos);
            Console.Write(' ');
        }

        protected void Move(Direction Direction)
        {
            switch(Direction)
            {
                case Direction.Up:
                    --_yPos;
                    --_oyPos;
                    break;
                case Direction.Down:
                    ++_yPos;
                    ++_oyPos;
                    break;
                case Direction.Left:
                    --_xPos;
                    --_oxPos;
                    break;
                case Direction.Right:
                    ++_xPos;
                    ++_oxPos;
                    break;
                default: break;
            }
        }

        protected enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        #region Fields

        private int _xPos, _yPos, _oxPos, _oyPos;
        private ConsoleColor _color;
        private char _sprite;

        #endregion
    }
}
