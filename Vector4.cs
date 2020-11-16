using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Library
{
    public class Vector4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _w;

        public Vector4()
        {
            _x = 0;
            _y = 0;
            _z = 0;
            _w = 0;
        }

        public Vector4(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
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

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public float W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
            }
        }

        public Vector4 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static Vector4 Normalize(Vector4 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector4();
            return vector / vector.Magnitude;
        }


        public static Vector4 operator +(Vector4 Ihs, Vector4 rhs)
        {
            float x = Ihs.X + rhs.X;
            float y = Ihs.Y + rhs.Y;
            float z = Ihs.Z + rhs.Z;
            float w = Ihs.W + rhs.W;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator -(Vector4 Ihs, Vector4 rhs)
        {
            return new Vector4(Ihs.X - rhs.X, Ihs.Y - rhs.Y, Ihs.Z - rhs.Z, Ihs.W - rhs.W);
        }
        public static Vector4 operator *(Vector4 Ihs, float scalar)
        {
            return new Vector4(Ihs.X * scalar, Ihs.Y * scalar, Ihs.Z * scalar, Ihs.W * scalar);
        }

        public static Vector4 operator /(Vector4 Ihs, float scalar)
        {
            return new Vector4(Ihs.X / scalar, Ihs.Y / scalar, Ihs.Z / scalar, Ihs.W / scalar);
        }

        public static float DotProduct(Vector4 Ihs, Vector4 rhs)
        {
            return (Ihs.X * rhs.X +Ihs.Y * rhs.Y + Ihs.Z * rhs.Z + Ihs.W * rhs.W);
        }

    }
}

