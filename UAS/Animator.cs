using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;

namespace UAS
{
    class Animator
    {
        public float s;
        public float p;
        public float o;
        public static List<Animator> instances = new List<Animator>();

        public Animator(float speed = 1, float offset = 0)
        {
            p = 0;
            s = speed;
            o = offset;
            Animator.instances.Add(this);
        }

        public float Linear() {
            return p;
        }

        public float Bounce()
        {
            if (p >= 0 && p < 0.5)
            {
                return 2 * p;
            }
            else { 
                return (1 - p) * 2;
            }
        }

        public float Sin()
        {
            return (float)Math.Sin(p*1*(float)Math.PI);
        }

        public float Cos()
        {
            return (float)Math.Cos(p * 1 * (float)Math.PI);
        }

        public float MinMaxLinear(float min, float max) {
            float delta = max - min;
            return min + delta * Linear();
        }

        public float MinMaxSin(float min, float max)
        {
            float delta = max - min;
            return min + delta * Sin();
        }

        public float MinMaxCos(float min, float max)
        {
            float delta = max - min;
            return min + delta * Cos();
        }

        public float MinMaxBounce(float min, float max)
        {
            float delta = max - min;
            return min + delta * Bounce();
        }

        public static void Tick(FrameEventArgs e) {
            foreach (var instant in Animator.instances)
            {
                instant.p += instant.s;
                if (instant.p > 1.0 + instant.o) instant.p = 0;
            }
        }

     }
}
