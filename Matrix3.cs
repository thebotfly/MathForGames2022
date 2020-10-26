﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Library
{
    public class Matrix3
    {
        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;

        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;

        }

        public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public static Matrix3 operator +(Matrix3 Ihs, Matrix3 rhs)
        {
            return new Matrix3(Ihs.m11 + rhs.m11, Ihs.m12 + rhs.m12, Ihs.m13 + rhs.m13, Ihs.m21 + rhs.m21, Ihs.m22 + rhs.m22, Ihs.m23 + rhs.m23, Ihs.m31 + rhs.m31, Ihs.m32 + rhs.m32, Ihs.m33 + rhs.m33);
        }
        public static Matrix3 operator -(Matrix3 Ihs, Matrix3 rhs)
        {
            return new Matrix3(Ihs.m11 - rhs.m11, Ihs.m12 - rhs.m12, Ihs.m13 - rhs.m13, Ihs.m21 - rhs.m21, Ihs.m22 - rhs.m22, Ihs.m23 - rhs.m23, Ihs.m31 - rhs.m31, Ihs.m32 - rhs.m32, Ihs.m33 - rhs.m33);
        }

        public static Matrix3 operator *(Matrix3 Ihs, Matrix3 rhs)
        {
            return new Matrix3(
                Ihs.m11 * rhs.m11 + Ihs.m12 * rhs.m21 + Ihs.m13 * rhs.m31,
                + Ihs.m11 * rhs.m12 + Ihs.m12 * rhs.m22 + Ihs.m13 * rhs.m32,
                + Ihs.m11 * rhs.m13 + Ihs.m12 * rhs.m23 + Ihs.m13 * rhs.m33,
               Ihs.m21 * rhs.m11 + Ihs.m22 * rhs.m21 + Ihs.m23 * rhs.m31,
                +Ihs.m21 * rhs.m12 + Ihs.m22 * rhs.m22 + Ihs.m23 * rhs.m32,
                +Ihs.m21 * rhs.m13 + Ihs.m22 * rhs.m23 + Ihs.m23 * rhs.m33,
                Ihs.m31 * rhs.m11 + Ihs.m32 * rhs.m21 + Ihs.m33 * rhs.m31,
                +Ihs.m31 * rhs.m12 + Ihs.m32 * rhs.m22 + Ihs.m33 * rhs.m32,
                +Ihs.m31 * rhs.m13 + Ihs.m32 * rhs.m23 + Ihs.m33 * rhs.m33);
        }

    }
}
