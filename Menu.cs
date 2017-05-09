using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Menu
    {
        public static void Show()
        {
            DrawMenu();
        }

        private static void DrawMenu()
        {
            Console.SetCursorPosition(4, 3);
            Console.Write('╒');
            for (int i = 0; i < Console.WindowWidth - 10; ++i)
                Console.Write('─');
            Console.Write('╕');
            for (int i = 4; i < Console.WindowHeight - 4; ++i)
            {
                Console.SetCursorPosition(4, i);
                Console.Write('│');
                for (int j = 0; j < Console.WindowWidth - 10; ++j)
                    Console.Write(' ');
                Console.Write('│');
            }
            Console.SetCursorPosition(4, Console.WindowHeight - 4);
            Console.Write('╘');
            for (int i = 0; i < Console.WindowWidth - 10; ++i)
                Console.Write('─');
            Console.Write('╛');
        }
    }
}
