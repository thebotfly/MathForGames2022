using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{




    class Player : Actor
    {
        public Player(float x, float y, char icon = 'a', ConsoleColor _color = ConsoleColor.Red) : base(x, y, icon)
        {

        }
        public override void Update()
        {
            ConsoleKey keyPressed = Game.GetNextKey();

            switch (keyPressed)
            {
                case ConsoleKey.A:
                    _velocity.X = -1;
                    break;
                case ConsoleKey.D:
                    _velocity.X = 1;
                    break;
                case ConsoleKey.W:
                    _velocity.Y = -1;
                    break;
                case ConsoleKey.S:
                    _velocity.Y = 1;
                    break;
                default:
                    _velocity.X = 0;
                    _velocity.Y = 0;
                    break;
            }
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight + 1);

            if (_position.X < 0)
                _position.X++;
            if (_position.X >= Console.WindowWidth)
                _position.X--;
            if (_position.Y < 0)
                _position.Y++;
            if (_position.Y >= Console.WindowHeight)
                _position.Y--;
        }

    }
}
