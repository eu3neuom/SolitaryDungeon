using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame
{
    class Chest : Tile
    {
        public Chest() : base(true) { }

        public override void ExecuteBehaviour(object[] args)
        {
        }

        public override char Look()
        {
            return '■';
        }
    }
}
