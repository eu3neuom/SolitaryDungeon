using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame
{
    class Tile
    {
        protected Tile(bool IsSolid)
        {
            _solid = IsSolid;
        }

        public bool IsSolid
        {
            get { return _solid; }
            protected set { _solid = value; }
        }

        public virtual char Look()
        {
            return ' ';
        }

        public virtual void ExecuteBehaviour(params object[] args)
        {
            
        }

        public static Tile Empty()
        {
            return new Tile(false);
        }

        private bool _solid;
    }
}
