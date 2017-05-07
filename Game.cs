using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    static class Game
    {
        public static Level CurentLevel { get; set; }

        public static void Initialize()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 31;
            Console.BufferHeight = 31;
            Console.WindowWidth = 100;
            Console.BufferWidth = 100;
            Camera.RenderHeight = Console.WindowHeight;
            Camera.RenderWidth = 71;
            InGameMenu.Height = Console.WindowHeight;
            InGameMenu.Width = Console.WindowWidth - Camera.RenderWidth;
        }
    }
}
