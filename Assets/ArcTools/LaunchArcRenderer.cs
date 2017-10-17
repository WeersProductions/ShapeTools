using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    [SerializeField]
    private int _resolution;

    [SerializeField]
    private Vector3 _a;
    [SerializeField]
    private Vector3 _b;

    [SerializeField]
    private Vector3 _controlPoints = new Vector3(0, 10, 0);

    [SerializeField]
    private float _inwards;

    public int Resolution
    {
        get { return _resolution; }
        set { _resolution = value; }
    }

    public Vector3 A
    {
        get { return _a; }
        set { _a = value; }
    }

    public Vector3 B
    {
        get { return _b; }
        set { _b = value; }
    }

    public Vector3 ControlPoints
    {
        get { return _controlPoints; }
        set { _controlPoints = value; }
    }

    public float Inwards
    {
        get { return _inwards; }
        set { _inwards = value; }
    }

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// Populating the LineRenderer with the appropriate settings.
    /// </summary>
    public void RenderArc()
    {
        Vector3[] result = new Vector3[_resolution];

        Vector3[] points = { _a, Vector3.Lerp(_a, _b, _inwards) + _controlPoints, Vector3.Lerp(_b, _a, _inwards) + _controlPoints, _b };

        for (int i = 0; i < _resolution; i++)
        {
            float t = (float)i / (_resolution - 1);

            result[i] = BezierHelper.GetBezier(t, points);
        }
        _lineRenderer.positionCount = result.Length;
        _lineRenderer.SetPositions(result);
    }

    private void OnValidate()
    {
        _resolution = Mathf.Max(2, _resolution);
    }
}
