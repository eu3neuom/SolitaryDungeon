using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TopDownGame
{
    abstract class Character
    {
        protected Character(World World, int Xposition, int Yposition, ConsoleColor Color)
        {
            world = World;
            xPos = Xposition;
            yPos = Yposition;
            color = Color;
        }

        public World World
        {
            get { return world; }
        }

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Xpos
        {
            get { return xPos; }
            protected set { xPos = value; }
        }

        public int Ypos
        {
            get { return yPos; }
            protected set { yPos = value; }
        }

        public Point Orientation
        {
            get { return orientation; }
            protected set { orientation = value; }
        }

        public void Update()
        {
            Clear();
            ExecuteBehaviour();
            Draw();
        }

        protected abstract void ExecuteBehaviour();

        protected virtual char Look()
        {
            return ' ';
        }

        private void Draw()
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(world.DrawOrigin.X + xPos, world.DrawOrigin.Y + yPos);
            Console.Write(Look());
            Console.ForegroundColor = aux;
        }

        private void Clear()
        {
            Console.SetCursorPosition(world.DrawOrigin.X + xPos, world.DrawOrigin.Y + yPos);
            Console.Write(' ');
        }

        private World world;
        private int xPos, yPos;
        private ConsoleColor color;
        private Point orientation;
    }
}
