using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Wall : Tile
    {
        public Wall(char Sprite) : base(Sprite, ConsoleColor.DarkGray, true) { }

        public struct Sprites
        {
            public const char TopLeft = '╔';
            public const char TopRight = '╗';
            public const char BotLeft = '╚';
            public const char BotRight = '╝';
            public const char Horizontal = '═';
            public const char Vertical = '║';
            public const char InterTop = '╩';
            public const char InterBot = '╦';
            public const char InterLeft = '╣';
            public const char InterRight = '╠';
            public const char Intersection = '╬';
        }
    }
}
