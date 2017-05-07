using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Door : Tile
    {
        public Door(char Sprite, bool IsOpen) : base(Sprite, ConsoleColor.Gray, !IsOpen)
        {
            auxSprite = Sprite;
            if (IsOpen)
                this.Sprite = ' ';
            else
                this.Sprite = auxSprite;
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
                Sprite = auxSprite;
                InGameMenu.Log("You closed a door.");
            }
        }

        public struct Sprites
        {
            public const char Horizontal = '─';
            public const char Vertical = '│';
        }

        private char auxSprite;
    }
}
