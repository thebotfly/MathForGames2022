﻿using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        private char _icon = ' ';
        public Vector2 _position;
        public Vector2 _velocity;
        private ConsoleColor _color;
        protected Color _rayColor;

        public bool Started { get; private set; }

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



        public Actor( float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Green)
        {
            _rayColor = Color.GREEN;
            _icon = icon;
            _position = new Vector2(x, y);
            _velocity = new Vector2(x, y);
            _color = color;
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Green)
            : this(x,y,icon,color)
        {
            _rayColor = rayColor;
          
        }
       
     
        

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update()
        {
            
            
            _position += _velocity;
           _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth-1);
           _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight+1);

            
            
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(),(int) _position.X*32,(int) _position.Y*32, 32,_rayColor);
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X,(int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }

    }
}
