using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SolitaryDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Initialize();
            Level lvl1 = new Level(10, 10);
            Game.CurentLevel = lvl1;
            Player p = new Player(lvl1, 3, 3);
            Zombie z = new Zombie(lvl1, 8, 8);

            while (Game.IsAlive)
            {
                Thread.Sleep(16);
                p.Update();
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("!TZEAPA!");
            Console.ReadKey();
        }
    }
}
