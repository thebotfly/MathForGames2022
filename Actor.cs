using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;

namespace MathForGames
{
    class Actor
    {
        private char _icon = 'a';
        public Vector2 _position;
        public Vector2 _velocity;
        private ConsoleColor _color;

        public float X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
            }
        }

        public float Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }
         public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
            
        }



        public Actor( float x, float y, char icon = 'a', ConsoleColor color = ConsoleColor.Green)
        {

            _icon = icon;
            _position = new Vector2(x, y);
            _velocity = new Vector2(x, y);
            _color = color;
        }


       
     
        

        public virtual void Start()
        {
           
        }

        public virtual void Update()
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
           _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth-1);
           _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight+1);

            if (_position.X < 0)
                _position.X++;
            if (_position.X >= Console.WindowWidth)
                _position.X--;
            if (_position.Y < 0)
                _position.Y++;
            if (_position.Y >= Console.WindowHeight)
                _position.Y--;
            
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X,(int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {

        }

    }
}
