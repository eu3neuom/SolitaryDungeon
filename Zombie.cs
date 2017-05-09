using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Zombie : Character
    {
        public Zombie(Level Level, int Xposition, int Yposition) : base(Level, Xposition, Yposition, ConsoleColor.Green)
        {
            Sprite = '¶';
        }

        protected override void ExecuteBehaviour()
        {
            Player p = Level.Player;
            if (Pathfinding.IsNextTo(this, p))
            {
                int damage = new Random().Next(2, 5);
                p.TakeDamage(damage);
                InGameMenu.Log("You took " + damage + " from a zombie.");
            }
            else
                Move(Pathfinding.NextStep(Xpos, Ypos, p.Xpos, p.Ypos));
        }
    }
}
