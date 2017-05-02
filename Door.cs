using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame
{
    class Door : Tile
    {
        public Door(Sprite Sprite, bool IsOpen = false) : base(!IsOpen)
        {
            switch (Sprite)
            {
                case Sprite.Horizontal:
                    sprite = '─';
                    break;
                case Sprite.Vertical:
                    sprite = '│';
                    break;
                default: break;
            }
        }

        public override void ExecuteBehaviour(object[] args)
        {
            if (IsSolid)
            {
                IsSolid = false;
                Menu.Log("You opened a door");
            }
            else
            {
                IsSolid = true;
                Menu.Log("You closed a door");
            }
        }

        public override char Look()
        {
            if (IsSolid)
                return sprite;
            else
                return ' ';
        }

        public enum Sprite
        {
            Horizontal,
            Vertical
        }

        private char sprite;
    }
}
