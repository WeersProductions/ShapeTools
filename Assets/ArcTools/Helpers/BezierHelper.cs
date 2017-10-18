using UnityEngine;


namespace WeersProductions.ArcTools
{
    public static class BezierHelper
    {
        public static Vector2 GetBezier(float t, params Vector2[] points)
        {
            return GetBezier(t, 0, points.Length - 1, points);
        }

        private static Vector2 GetBezier(float t, int start, int end, params Vector2[] points)
        {
            if (start == end)
            {
                return points[start];
            }
            return (1 - t) * GetBezier(t, start, end - 1, points) +
                   t * GetBezier(t, start + 1, end, points);
        }

        public static Vector3 GetBezier(float t, params Vector3[] points)
        {
            return GetBezier(t, 0, points.Length - 1, points);
        }

        private static Vector3 GetBezier(float t, int start, int end, params Vector3[] points)
        {
            if (start == end)
            {
                return points[start];
            }
            return (1 - t) * GetBezier(t, start, end - 1, points) +
                   t * GetBezier(t, start + 1, end, points);
        }
    }
}



