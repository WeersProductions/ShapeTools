using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeersProductions.ShapeTools
{
    /// <summary>
    /// Class that contains mathematical help functions to calculate shapes.
    /// </summary>
    public static class ShapeHelper
    {
        /// <summary>
        /// Get a point on the circle at part t.
        /// </summary>
        /// <param name="origin">Center of the circle.</param>
        /// <param name="t"></param>
        /// <param name="radius">Radius of the circle.</param>
        /// <returns></returns>
        public static Vector2 Circle(Vector2 origin, float t, float radius)
        {
            return new Vector2(origin.x + radius * Mathf.Cos(t * 2 * Mathf.PI), origin.y + radius * Mathf.Sin(t * 2 * Mathf.PI));
        }
    }
}