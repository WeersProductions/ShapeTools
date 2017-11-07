using UnityEngine;


namespace WeersProductions.ArcTools
{
    /// <summary>
    /// Contains functions for Bezier calculations.
    /// </summary>
    public static class BezierHelper
    {
        /// <summary>
        /// Get the point on part t of the bezier.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="points">Points of the bezier curve.</param>
        /// <returns></returns>
        public static Vector2 GetBezier(float t, params Vector2[] points)
        {
            return GetBezier(t, 0, points.Length - 1, points);
        }

        /// <summary>
        /// Recursive function to get the point. Reuses the same array every time.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="start">Start index of the array.</param>
        /// <param name="end">End index of the array.</param>
        /// <param name="points">Total array of points.</param>
        /// <returns></returns>
        private static Vector2 GetBezier(float t, int start, int end, params Vector2[] points)
        {
            if (start == end)
            {
                return points[start];
            }
            return (1 - t) * GetBezier(t, start, end - 1, points) +
                   t * GetBezier(t, start + 1, end, points);
        }
        /// <summary>
        /// Get the point on part t of the bezier in 3d.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="points">Points of the bezier curve.</param>
        /// <returns></returns>
        public static Vector3 GetBezier(float t, params Vector3[] points)
        {
            return GetBezier(t, 0, points.Length - 1, points);
        }

        /// <summary>
        /// Recursive function to get the point. Reuses the same array every time.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="start">Start index of the array.</param>
        /// <param name="end">End index of the array.</param>
        /// <param name="points">Total array of points.</param>
        /// <returns></returns>
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



