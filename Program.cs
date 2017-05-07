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
            Level lvl1 = new Level(20, 20);
            Game.CurentLevel = lvl1;
            Player p = new Player(lvl1, 3, 3);
            while (true)
            {
                Thread.Sleep(16);
                p.Update();
            }
        }
    }
}
