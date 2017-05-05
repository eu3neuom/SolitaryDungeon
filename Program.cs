using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Level lvl1 = new Level(20, 20);
            lvl1.Draw();
            Console.ReadKey();
        }
    }
}
