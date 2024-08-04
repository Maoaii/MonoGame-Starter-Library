namespace MonoGameLibrary.Utilities {
    public static class Easing {
       public static float Linear(float t, float b, float c, float d) {
            return c * t / d + b;
        }

        public static float QuadraticIn(float t, float b, float c, float d) {
            t /= d;
            return c * t * t + b;
        }

        public static float QuadraticOut(float t, float b, float c, float d)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }

        public static float InOutQuadratic(float t, float b, float c, float d) {
            t /= d / 2;
            if (t < 1) return (c / 2 * t * t) + b;
            else return -c / 2 * ((t - 1) * (t - 3) - 1) + b;
        }
    }
}