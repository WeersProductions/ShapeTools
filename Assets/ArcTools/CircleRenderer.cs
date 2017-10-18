using UnityEngine;

namespace WeersProductions.ArcTools
{
    public class CircleRenderer : ShapeRenderer
    {
        [SerializeField] private float _radius;

        [SerializeField] private Vector3 _origin;

        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public Vector3 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public override void Render()
        {
            Vector3[] points = new Vector3[Resolution];

            Vector2 circleOrigin = new Vector2(_origin.x, _origin.z);

            for (int i = 0; i < Resolution; i++)
            {
                float t = (float) i / (Resolution - 1);

                points[i] = ShapeHelper.Circle(circleOrigin, t, _radius);
                points[i] = new Vector3(points[i].x, _origin.y, points[i].y);
            }

            ApplyPositions(points);
        }
    }
}