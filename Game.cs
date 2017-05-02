using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace TopDownGame
{
    class Game
    {
        private static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = 100;
            Console.BufferWidth = 100;
            Console.WindowHeight = 31;
            Console.BufferHeight = 31;

            int mapWidth = Console.WindowWidth - Menu.Width;

            World floor = new World(72, 30);
            Menu.World = floor;
            floor.DrawOrigin = new Point(0, 0);
            Player p = new Player(floor, 4, 5);
            Zombie z1 = new Zombie(floor, 4, 20);

            while (true)
            {
                Thread.Sleep(10);
                p.Update();
            }
        }
    }
}
