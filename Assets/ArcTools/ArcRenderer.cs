using UnityEngine;

namespace WeersProductions.ArcTools
{
    public class ArcRenderer : ShapeRenderer
    {
        [SerializeField] private Vector3 _a;
        [SerializeField] private Vector3 _b;

        [SerializeField] private Vector3 _controlPoints = new Vector3(0, 10, 0);

        [SerializeField] private float _inwards;

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