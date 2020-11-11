using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = ' ';
        protected Vector2 _velocity;
        protected Matrix3 _globalTransform;
        protected Matrix3 _localtransform;
        protected Matrix3 _translation = new Matrix3();
        protected Matrix3 _rotation = new Matrix3();
        protected Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        protected float _rotationAngle;
        private float _collisionRadius;

        public bool Started { get; private set; }

        public void SetTranslate(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void SetScale(float X, float Y)
        {
            _scale = Matrix3.CreateScale(new Vector2(X, Y));
        }

        public void UpdateTransform()
        {
            _localtransform = _translation * _rotation * _scale;

            if (_parent != null)
                _globalTransform = _parent._globalTransform * _localtransform;
            else
                _globalTransform = Game.GetCurrentScene().World * _localtransform;
        }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_localtransform.m11, _localtransform.m21);
            }
            set
            {
                _localtransform.m11 = value.X;
                _localtransform.m21 = value.Y;
            }
           
        }


        public float X
        {
            get
            {
                return LocalPosition.X;
            }
            set
            {
                LocalPosition.X = value;
            }
        }

        public float Y
        {
            get
            {
                return LocalPosition.Y;
            }
            set
            {
                LocalPosition.Y = value;
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

        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localtransform.m13, _localtransform.m23);
            }
            set
            {
                _localtransform.m13 = value.X;
                _localtransform.m23 = value.Y;
            }
            
        }

        public bool CheckCollision(Actor other)
        {
            return false;
        }

        

        public virtual void OnCollision(Actor other)
        {

        }



        public Actor( float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Green)
        {
            _rayColor = Color.GREEN;
            _icon = icon;
            _localtransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2(x, y);
            _color = color;
            Forward = new Vector2(1, 0);
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Green)
            : this(x,y,icon,color)
        {
            _rayColor = rayColor;
            _localtransform = new Matrix3();
          
        }

        public void AddChild(Actor child)
        {
            Actor[] tempArray = new Actor[_children.Length + 1];
            for(int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;
            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for(int i = 0; i <_children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                    
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }

        private void UpdateFacing(Vector2 _facing)
        {
            if (_velocity.Magnitude <= 0)
                return;

            _facing = Velocity.Normalized;
        }
       
     
        

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            LocalPosition += _velocity * deltaTime;
           LocalPosition.X = Math.Clamp(LocalPosition.X, 0, Console.WindowWidth-1);
           LocalPosition.Y = Math.Clamp(LocalPosition.Y, 0, Console.WindowHeight+1);
            UpdateTransform();


        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)WorldPosition.X * 32, (int)WorldPosition.Y * 32, 32, _rayColor);
            Raylib.DrawLine((int)WorldPosition.X * 32, (int)WorldPosition.Y * 32, (int)WorldPosition.X + (Forward.X * 32)),(int)WorldPosition.Y + (Forward.Y * 32)) _rayColor);
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)WorldPosition.X,(int)WorldPosition.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;

        }

        public virtual void End()
        {
            Started = false;
        }

    }
}
