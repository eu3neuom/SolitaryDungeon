using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame
{
    class Zombie : Character
    {
        public Zombie(World World, int Xposition, int Yposition) : base(World, Xposition, Yposition, ConsoleColor.DarkGreen)
        {
            World.Characters.Add(this);
        }

        protected override void ExecuteBehaviour()
        {
            Player target = World.Player;
            if (Modul(target.Xpos - Xpos) + Modul(target.Ypos - Ypos) == 1)
                target.TakeDamage(damage);
            else if (target.Xpos > Xpos && !World.CheckCollision(Xpos + 1, Ypos))
                ++Xpos;
            else if (target.Xpos < Xpos && !World.CheckCollision(Xpos - 1, Ypos))
                --Xpos;
            else if (target.Ypos > Ypos && !World.CheckCollision(Xpos, Ypos + 1))
                ++Ypos;
            else if (target.Ypos < Ypos && !World.CheckCollision(Xpos, Ypos - 1))
                --Ypos;
        }

        protected override char Look()
        {
            return '¶';
        }

        private int Modul(int x)
        {
            if (x < 0)
                return -x;
            return x;
        }

        private int damage = 3;
    }
}
