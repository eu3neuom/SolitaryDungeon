using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TopDownGame
{
    class Player : Character
    {
        public Player(World World, int Xposition, int Yposition) : base(World, Xposition, Yposition, ConsoleColor.White)
        {
            World.Player = this;
            health = 16;
            World.Update();
            Menu.Update();
        }

        public int Health
        {
            get { return health; }
        }

        public void TakeDamage(int Value)
        {
            health -= Value;
            if (health < 0)
            {
                isAlive = false;
                Menu.Log("You died");
                Color = ConsoleColor.Red;
                sprite = '#';
            }
        }

        protected override void ExecuteBehaviour()
        {
            // here is the control for the entire game
            if (Console.KeyAvailable && isAlive)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.W:
                        Orientation = new Point(Xpos, Ypos - 1);
                        sprite = '▲';
                        if (!World.CheckCollision(Orientation))
                        {
                            --Ypos;
                            Orientation = new Point(Xpos, Ypos - 1);
                        }
                        goto default;
                    case ConsoleKey.S:
                        Orientation = new Point(Xpos, Ypos + 1);
                        sprite = '▼';
                        if (!World.CheckCollision(Orientation))
                        {
                            ++Ypos;
                            Orientation = new Point(Xpos, Ypos + 1);
                        }
                        goto default;
                    case ConsoleKey.A:
                        Orientation = new Point(Xpos - 1, Ypos);
                        sprite = '◄';
                        if (!World.CheckCollision(Orientation))
                        {
                            --Xpos;
                            Orientation = new Point(Xpos - 1, Ypos);
                        }
                        goto default;
                    case ConsoleKey.D:
                        Orientation = new Point(Xpos + 1, Ypos);
                        sprite = '►';
                        if (!World.CheckCollision(Orientation))
                        {
                            ++Xpos;
                            Orientation = new Point(Xpos + 1, Ypos);
                        }
                        goto default;
                    case ConsoleKey.E:
                        World.Interact(Orientation);
                        goto default;
                    default:
                        World.Update();
                        Menu.Update();
                        break;
                }
            }
        }

        protected override char Look()
        {
            return sprite;
        }

        private char sprite = '☻';
        private bool isAlive = true, hasWeapon = false;
        private int health;
    }
}
