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
            ClearRenderArea();
            for (int i = 0; i < Game.CurrentLevel.Height; ++i)
            {
                if(_xCenter - Game.CurrentLevel.Player.Xpos < _renderWidth 
                   && _yCenter - Game.CurrentLevel.Player.Ypos + i >= 0 && _yCenter - Game.CurrentLevel.Player.Ypos + i < _renderHeight)
                {
                    int dif = _xCenter - Game.CurrentLevel.Player.Xpos;
                    int aux = 0;
                    if (dif < 0) aux = -dif;

                    Console.SetCursorPosition(Math.Max(dif, 0), _yCenter - Game.CurrentLevel.Player.Ypos + i);
                    for (int j = aux; j < Game.CurrentLevel.Width && j + _xCenter - Game.CurrentLevel.Player.Xpos < _renderWidth; ++j)
                        Game.CurrentLevel.Map[i, j].Draw();
                }
            }

            for (int i = 1; i < Game.CurrentLevel.Characters.Count; ++i)
            {
                Console.SetCursorPosition(_xCenter - Game.CurrentLevel.Player.Xpos + Game.CurrentLevel.Characters[i].Xpos,
                    _yCenter - Game.CurrentLevel.Player.Ypos + Game.CurrentLevel.Characters[i].Ypos);
                    Game.CurrentLevel.Characters[i].Draw();
            }

            Console.SetCursorPosition(_xCenter, _yCenter);
            Game.CurrentLevel.Player.Draw();
        }

        private static void ClearRenderArea()
        {
            for (int i = 0; i < _renderHeight ; ++i)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < _renderWidth; ++j)
                {
                    Console.Write(' ');
                }
            }
        }

        #region Fields

        private static int _renderWidth, _renderHeight, _xCenter, _yCenter;

        #endregion
    }
}
