using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Crossbone.Utils
{
    internal struct Vector2
    {
        public Vector2f vector;
        public float X { get { return vector.X; } }
        public float Y { get { return vector.Y; } }

        public Vector2(Vector2f vector)
        {
            this.vector = vector;
        }

        public Vector2(float x, float y)
        {
            vector = new Vector2f(x, y);
        }

        public Vector2()
        {
            vector = new Vector2f();
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.vector + v2.vector);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.vector - v2.vector);
        }

        public static Vector2 operator *(Vector2 v, float x)
        {
            return new Vector2(v.X * x, v.Y * x);
        }

        public static Vector2 operator *(float x, Vector2 v)
        {
            return new Vector2(v.X * x, v.Y * x);
        }

        public static Vector2 operator /(Vector2 v, float x)
        {
            return new Vector2(v.X / x, v.Y / x);
        }

        public static Vector2 operator /(float x, Vector2 v)
        {
            return new Vector2(v.X / x, v.Y / x);
        }

        public float Magnitude
        {
            get { return (float) Math.Sqrt(X * X + Y * Y);}
        }

        public Vector2 Normilized
        {
            get { return Magnitude > 0 ? new Vector2(vector) / Magnitude : this; }
        }
    }
}
