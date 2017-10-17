using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierHelper
{
    public static Vector2 GetBezier(float t, params Vector2[] points)
    {
        if (points.Length == 1)
        {
            return points[0];
        }
        return (1 - t) * GetBezier(t, points.SubArray(0, points.Length - 1)) +
               t * GetBezier(t, points.SubArray(1, points.Length - 1));
    }

    public static Vector3 GetBezier(float t, params Vector3[] points)
    {
        if (points.Length == 1)
        {
            return points[0];
        }
        return (1 - t) * GetBezier(t, points.SubArray(0, points.Length - 1)) +
               t * GetBezier(t, points.SubArray(1, points.Length - 1));
    }

    public static Vector2 GetQuadraticPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2)
    {
        return Vector2.Lerp(GetLinearPoint(t, p0, p1), GetLinearPoint(t, p1, p2), t);
    }

    public static Vector2 GetLinearPoint(float t, Vector2 p0, Vector2 p1)
    {
        return Vector2.Lerp(p0, p1, t);
    }


    public static T[] SubArray<T>(this T[] data, int index, int length)
    {
        T[] result = new T[length];
        Array.Copy(data, index, result, 0, length);
        return result;
    }
}


