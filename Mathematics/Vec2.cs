using System;

namespace Asteroids2D_GameLogic.Mathematics
{
    public struct Vec2
    {
        public float x;
        public float y;

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vec2 vec &&
                   x == vec.x &&
                   y == vec.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
        public static Vec2 up { get { return new Vec2(0, 1f); } }
        public static Vec2 down { get { return new Vec2(0, -1f); } }
        public static Vec2 right { get { return new Vec2(-1, 0); } }
        public static Vec2 left { get { return new Vec2(1, 0); } }
        public Vec2 normalize
        {
            get
            {
                try
                {
                    float inv_length = 1.0f / (float)Math.Sqrt(x * x + y * y);
                    return this * inv_length;
                }
                catch (DivideByZeroException)
                {
                    return new Vec2();
                }
            }
        }
        public float magnitude
        {
            get
            {
                try
                {
                    return (float)Math.Sqrt(x * x + y * y);
                }
                catch (DivideByZeroException)
                {
                    return 0;
                }
            }
        }
        public float module { get { return Math.Abs(x * x + y * y); } }
        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x + b.x, a.y + b.y);
        }
        public static Vec2 operator -(Vec2 a)
        {
            return new Vec2(-a.x, -a.y);
        }
        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x - b.x, a.y - b.y);
        }
        public static Vec2 operator *(float d, Vec2 a)
        {
            return new Vec2(a.x * d, a.y * d);
        }
        public static Vec2 operator *(Vec2 a, float d)
        {
            return new Vec2(a.x * d, a.y * d);
        }
        public static Vec2 operator *(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x * b.x, a.y * b.y);
        }
        public static Vec2 operator /(Vec2 a, float d)
        {
            if (d == 0)
            {
                new DivideByZeroException();
            }
            return new Vec2(a.x / d, a.y / d);
        }
        public static Vec2 operator /(Vec2 a, Vec2 b)
        {
            if (b.x == 0 || b.y == 0)
            {
                new DivideByZeroException();
            }
            return new Vec2(a.x / b.x, a.y / b.y);
        }
        public static bool operator ==(Vec2 lhs, Vec2 rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }
        public static bool operator !=(Vec2 lhs, Vec2 rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }
    }
}
