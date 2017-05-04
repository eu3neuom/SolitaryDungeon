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
            _color = Color;
        }

        protected virtual char Look()
        {
            return ' ';
        }

        public void Update()
        {
            Clear();
            ExecuteBehaviour();
            Draw();
        }

        private void Draw()
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_xPos, _yPos);
            Console.Write(Look());
            Console.ForegroundColor = aux;
        }

        private void Clear()
        {
            Console.SetCursorPosition(_xPos, _yPos);
            Console.Write(' ');
        }

        public abstract void ExecuteBehaviour();

        private int _xPos, _yPos, _oxPos, _oyPos;
        private ConsoleColor _color;
    }
}
