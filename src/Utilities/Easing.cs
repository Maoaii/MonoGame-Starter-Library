using System;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Utilities {

    /// <summary>
    /// https://github.com/EmmanuelOga/easing/blob/master/lib/easing.lua
    /// </summary>
    public static partial class Easing {

        public static class Linear {
            public static float In(float t, float b, float c, float d) {
                if (t > d) t = d;
                return c * t / d + b;
            }

            public static float Out(float t, float b, float c, float d) {
                if (t > d) t = d;
                return c * t / d + b;
            }

            public static float InOut(float t, float b, float c, float d) {
                if (t > d) t = d;
                return c * t / d + b;
            }
        }

        public static class Quadratic {
            public static float In(float t, float b, float c, float d) {
                if (t > d) t = d;
                return c * (t /= d) * t * t * t + b;
            }

            public static float Out(float t, float b, float c, float d)
            {  
                if (t > d) t = d;
                return -c * ((t = t / d - 1) * t * t * t - 1) + b;
            }

            public static float InOut(float t, float b, float c, float d) {
                if (t > d) t = d;
                if ( (t /= d / 2) < 1 ) {
                    return c / 2 * t * t * t * t + b;
                }
                return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
            }
        }
    }
}