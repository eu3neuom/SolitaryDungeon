using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Player : Character
    {
        public Player(Level Level, int Xposition, int Yposition) : base(Level, Xposition, Yposition, ConsoleColor.White)
        {
            Sprite = '☻';
            Camera.Render();
            InGameMenu.Update();
        }

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
                        goto default;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Sprite = '▼';
                        Move(Direction.Down);
                        goto default;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Sprite = '◄';
                        Move(Direction.Left);
                        goto default;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Sprite = '►';
                        Move(Direction.Right);
                        goto default;
                    case ConsoleKey.E:
                        Level.Interact(Xorient, Yorient);
                        goto default;
                    default:
                        Camera.Render();
                        InGameMenu.Update();
                        Level.Update();
                        break;
                } 
            }
        }
    }
}