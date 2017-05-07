using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    static class InGameMenu
    {
        #region Properties

        public static int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public static int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        #endregion

        public static void Update()
        {
            DrawBorder();
            UpdateLog();
        }

        public static void Log(string LogString)
        {
            _events.Enqueue(LogString);
        }

        private static void DrawBorder()
        {
            // ─,│,┌,┐,└,┘,├,┤,┬,┴,┼
            Console.SetCursorPosition(Console.WindowWidth - _width, 0);
            Console.Write('┌');
            for (int i = 1; i <= _width - 2; ++i)
                Console.Write('─');
            Console.Write('┐');
            for (int i = 1; i <= _height - 3; ++i)
            {
                Console.SetCursorPosition(Console.WindowWidth - _width, i);
                Console.Write('│');
                for (int j = 1; j <= _width - 2; j++)
                {
                    Console.Write(' ');
                }
                Console.Write('│');
            }
            Console.SetCursorPosition(Console.WindowWidth - _width, _height - 2);
            Console.Write('└');
            for (int i = 1; i <= _width - 2; ++i)
                Console.Write('─');
            Console.Write('┘');
            Console.SetCursorPosition(Console.WindowWidth - _width, _height - 9);
            Console.Write("├─LOG:");
            for (int i = 1; i < _width - 6; i++)
            {
                Console.Write('─');
            }
            Console.Write('┤');
        }

        private static void UpdateLog()
        {
            if (_events.Count > 6)
                _events.Dequeue();
            for (int i = 0; i < _events.Count; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - _width + 1, i + _height - 8);
                Console.Write(_events.ToArray()[i]);
            }
        }

        #region Fields

        private static int _width, _height;
        private static Queue<string> _events = new Queue<string>();

        #endregion
    }
}
