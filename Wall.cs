using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame
{
    class Wall : Tile
    {
        public Wall(Sprite Sprite) : base(true)
        {
            switch (Sprite)
            {
                case Sprite.TopLeft:
                    sprite = '╔';
                    break;
                case Sprite.TopRight:
                    sprite = '╗';
                    break;
                case Sprite.BotLeft:
                    sprite = '╚';
                    break;
                case Sprite.BotRight:
                    sprite = '╝';
                    break;
                case Sprite.Horizontal:
                    sprite = '═';
                    break;
                case Sprite.Vertical:
                    sprite = '║';
                    break;
                case Sprite.InterTop:
                    sprite = '╩';
                    break;
                case Sprite.InterBot:
                    sprite = '╦';
                    break;
                case Sprite.InterLeft:
                    sprite = '╣';
                    break;
                case Sprite.InterRight:
                    sprite = '╠';
                    break;
                default: break;
            }
        }

        public override char Look()
        {
            return sprite;
        }

        public enum Sprite
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

        private char sprite;
    }
}
