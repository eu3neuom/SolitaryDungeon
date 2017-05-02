using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame
{
    static class Menu
    {
        public static int Width
        {
            get { return width; }
        }

        public static World World
        {
            set { world = value; }
        }

        public static void Update()
        {
            DrawBorder();
            DisplayHealth();
            UpdateLog();
        }

        public static void Log(string LogString)
        {
            Events.Enqueue(LogString);
        }

        private static void DisplayHealth()
        {
            Console.SetCursorPosition(Console.WindowWidth - width + 1, 1);
            Console.Write("Health: ");
            for (int i = 1; i <= world.Player.Health; i++)
            {
                Console.Write('▓');
            }
        }

        private static void UpdateLog()
        {
            if (Events.Count > 6)
                Events.Dequeue();
            for (int i = 0; i < Events.Count; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - width + 1, i + height - 8);
                Console.Write(Events.ToArray()[i]);
            }
        }

        private static void DrawBorder()
        {
            // ─,│,┌,┐,└,┘,├,┤,┬,┴,┼
            Console.SetCursorPosition(Console.WindowWidth - width, 0);
            Console.Write('┌');
            for (int i = 1; i <= width - 2; ++i)
                Console.Write('─');
            Console.Write('┐');
            for (int i = 1; i <= height - 3; ++i)
            {
                Console.SetCursorPosition(Console.WindowWidth - width, i);
                Console.Write('│');
                for (int j = 1; j <= width - 2; j++)
                {
                    Console.Write(' ');
                }
                Console.Write('│');
            }
            Console.SetCursorPosition(Console.WindowWidth - width, height - 2);
            Console.Write('└');
            for (int i = 1; i <= width - 2; ++i)
                Console.Write('─');
            Console.Write('┘');
            Console.SetCursorPosition(Console.WindowWidth - width, height - 9);
            Console.Write("├─LOG:");
            for (int i = 1; i < width - 6; i++)
            {
                Console.Write('─');
            }
            Console.Write('┤');
        }

        private static int width = 26;
        private static int height = Console.WindowHeight;
        private static World world;

        private static Queue<string> Events = new Queue<string>();
    }
}
