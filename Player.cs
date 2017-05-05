using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Player : Character
    {
        public Player(Level Level, int Xposition, int Yposition) : base(Level, Xposition, Yposition, ConsoleColor.White) { }

        protected override void ExecuteBehaviour()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Sprite = '▲';
                        Move(Direction.Up);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Sprite = '▼';
                        Move(Direction.Down);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Sprite = '◄';
                        Move(Direction.Left);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Sprite = '►';
                        Move(Direction.Right);
                        break;
                    default: break;
                }
            }
        }
    }
}
