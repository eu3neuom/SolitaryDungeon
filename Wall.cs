using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    class Wall : Tile
    {
        public Wall(Type Type) : base(ConsoleColor.DarkGray, true)
        {
            switch (Type)
            {
                case Type.TopLeft:
                    Sprite = '╔';
                    break;
                case Type.TopRight:
                    Sprite = '╗';
                    break;
                case Type.BotLeft:
                    Sprite = '╚';
                    break;
                case Type.BotRight:
                    Sprite = '╝';
                    break;
                case Type.Horizontal:
                    Sprite = '═';
                    break;
                case Type.Vertical:
                    Sprite = '║';
                    break;
                case Type.InterTop:
                    Sprite = '╩';
                    break;
                case Type.InterBot:
                    Sprite = '╦';
                    break;
                case Type.InterLeft:
                    Sprite = '╣';
                    break;
                case Type.InterRight:
                    Sprite = '╠';
                    break;
                default: break;
            }
        }

        public enum Type
        {
            TopLeft,
            TopRight,
            BotLeft,
            BotRight,
            Horizontal,
            Vertical,
            InterTop,
            InterBot,
            InterLeft,
            InterRight
        }
    }
}
