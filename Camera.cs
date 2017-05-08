using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    static class Camera
    {
        #region Properties

        public static int RenderWidth
        {
            get { return _renderWidth; }
            set
            {
                _renderWidth = value;
                _xCenter = _renderWidth / 2;
            }
        }
        public static int RenderHeight
        {
            get { return _renderHeight; }
            set
            {
                _renderHeight = value;
                _yCenter = _renderHeight / 2;
            }
        }

        #endregion

        public static void Render()
        {
            Console.Clear();
            for (int i = 0; i < Game.CurentLevel.Height; ++i)
            {
                if(_xCenter - Game.CurentLevel.Player.Xpos > 0 && _xCenter - Game.CurentLevel.Player.Xpos < _renderWidth 
                   && _yCenter - Game.CurentLevel.Player.Ypos + i > 0 && _yCenter - Game.CurentLevel.Player.Ypos + i < _renderHeight)
                {
                    Console.SetCursorPosition(_xCenter - Game.CurentLevel.Player.Xpos, _yCenter - Game.CurentLevel.Player.Ypos + i);
                    for (int j = 0; j < Game.CurentLevel.Width; ++j)
                        Game.CurentLevel.Map[i, j].Draw();
                }
            }

            for (int i = 1; i < Game.CurentLevel.Characters.Count; ++i)
            {
                Console.SetCursorPosition(_xCenter - Game.CurentLevel.Player.Xpos + Game.CurentLevel.Characters[i].Xpos,
                    _yCenter - Game.CurentLevel.Player.Ypos + Game.CurentLevel.Characters[i].Ypos);
                    Game.CurentLevel.Characters[i].Draw();
            }

            Console.SetCursorPosition(_xCenter, _yCenter);
            Game.CurentLevel.Player.Draw();
        }

        #region Fields

        private static int _renderWidth, _renderHeight, _xCenter, _yCenter;

        #endregion
    }
}
