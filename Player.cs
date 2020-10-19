using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MathForGames
{




    class Player : Actor
    {
        public Player( float x, float y,  char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }

        public Player( float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }
        public override void Update()
        {

            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A)) + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W)) + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight + 1);

           
        }

    }
}
