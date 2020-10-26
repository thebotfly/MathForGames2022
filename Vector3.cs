using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Library
{
    class Vector3
    {
        private float _x;
        private float _y;

        public Vector3()
        {
            _x = 0;
            _y = 0;
        }

        public Vector3(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }

        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }

        public Vector3 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static Vector3 Normalize(Vector3 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector3();
            return vector / vector.Magnitude;
        }


        public static Vector3 operator +(Vector3 Ihs, Vector3 rhs)
        {
            float x = Ihs.X + rhs.X;
            float y = Ihs.Y + rhs.Y;

            return new Vector3(x, y);
        }

        public static Vector3 operator -(Vector3 Ihs, Vector3 rhs)
        {
            return new Vector3(Ihs.X - rhs.X, Ihs.Y - rhs.Y);
        }
        public static Vector3 operator *(Vector3 Ihs, float scalar)
        {
            return new Vector3(Ihs.X * scalar, Ihs.Y * scalar);
        }

        public static Vector3 operator /(Vector3 Ihs, float scalar)
        {
            return new Vector3(Ihs.X / scalar, Ihs.Y / scalar);
        }

        public static Vector3 DotProduct(Vector3 Ihs, Vector3 rhs)
        {
            return (Ihs.X * rhs.X, +Ihs.Y * rhs.Y);
        }

    }
}
