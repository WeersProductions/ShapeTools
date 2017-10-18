using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeersProductions.ArcTools
{
    public static class ShapeHelper
    {
        public static Vector2 Circle(Vector2 origin, float t, float radius)
        {
            return new Vector2(origin.x + radius * Mathf.Cos(t * 2 * Mathf.PI), origin.y + radius * Mathf.Sin(t * 2 * Mathf.PI));
        }
    }
}