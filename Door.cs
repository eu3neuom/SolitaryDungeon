using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Door : Tile
    {
        public Door(Type Type, bool IsOpen) : base(ConsoleColor.Gray, !IsOpen)
        {
            switch (Type)
            {
                case Type.Horizontal:
                    _auxSprite = '─';
                    break;
                case Type.Vertical:
                    _auxSprite = '│';
                    break;
                default: break;
            }
            if (IsOpen)
                Sprite = ' ';
            else
                Sprite = _auxSprite;
        }

        public override void ExecuteBehaviour()
        {
            if (IsSolid)
            {
                IsSolid = false;
                Sprite = ' ';
                InGameMenu.Log("You opened a door.");
            }
            else
            {
                IsSolid = true;
                Sprite = _auxSprite;
                InGameMenu.Log("You closed a door.");
            }
        }

        public enum Type
        {
            Horizontal,
            Vertical
        }

    #region Fields

        private char _auxSprite;

    #endregion
    }
}
