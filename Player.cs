using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Math_Library;

namespace MathForGames
{




    class Player : Actor
    {
        private float _speed = 1;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public Player( float x, float y,  char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }

        public Player( float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }
        public override void Update(float deltaTime)
        {

            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A)) + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W)) + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));
            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);

            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight + 1);

           
        }

    }
}
