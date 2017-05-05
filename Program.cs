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
            Console.CursorVisible = false;

            Level lvl1 = new Level(20, 20);
            Player p = new Player(lvl1, 3, 3);
            while (true)
            {
                Thread.Sleep(16);
                lvl1.Update();
                p.Update();
            }
            Console.ReadKey();
        }
    }
}
