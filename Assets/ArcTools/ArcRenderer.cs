using UnityEngine;

namespace WeersProductions.ArcTools
{
    /// <inheritdoc />
    /// <summary>
    /// A renderer for bezier curves.
    /// </summary>
    public class ArcRenderer : ShapeRenderer
    {
        /// <summary>
        /// Start point.
        /// </summary>
        [SerializeField] private Vector3 _a;
        /// <summary>
        /// End point.
        /// </summary>
        [SerializeField] private Vector3 _b;

        /// <summary>
        /// The offset from the start and end points for the control points.
        /// These control points define the curve.
        /// </summary>
        [SerializeField] private Vector3 _controlPoints = new Vector3(0, 10, 0);

        /// <summary>
        /// The amount of inwards position of the controlPoints.
        /// </summary>
        [SerializeField] private float _inwards;

        /// <summary>
        /// Start point.
        /// </summary>
        public Vector3 A
        {
            get { return _a; }
            set { _a = value; }
        }

        /// <summary>
        /// End point.
        /// </summary>
        public Vector3 B
        {
            get { return _b; }
            set { _b = value; }
        }

        /// <summary>
        /// The offset from the start and end points for the control points.
        /// These control points define the curve.
        /// </summary>
        public Vector3 ControlPoints
        {
            get { return _controlPoints; }
            set { _controlPoints = value; }
        }

        /// <summary>
        /// The amount of inwards position of the controlPoints.
        /// </summary>
        public float Inwards
        {
            get { return _inwards; }
            set { _inwards = value; }
        }

        //private void Update()
        //{
        //    Render();
        //}

        /// <inheritdoc />
        /// <summary>
        /// Populating the LineRenderer with the appropriate settings.
        /// </summary>
        public override void Render()
        {
            Vector3[] result = new Vector3[Resolution];

            Vector3[] points =
            {
                _a, Vector3.Lerp(_a, _b, _inwards) + _controlPoints, Vector3.Lerp(_b, _a, _inwards) + _controlPoints, _b
            };

            for (int i = 0; i < Resolution; i++)
            {
                float t = (float)i / (Resolution - 1);

                result[i] = BezierHelper.GetBezier(t, points);
            }

            ApplyPositions(result);
        }
    }
}