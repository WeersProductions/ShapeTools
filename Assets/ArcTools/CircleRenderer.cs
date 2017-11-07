using UnityEngine;

namespace WeersProductions.ArcTools
{
    /// <inheritdoc />
    /// <summary>
    /// Renders a simple Circle.
    /// </summary>
    public class CircleRenderer : ShapeRenderer
    {
        /// <summary>
        /// Defines the radius of the circle.
        /// </summary>
        [SerializeField] private float _radius;

        /// <summary>
        /// Defines the origin of the circle.
        /// </summary>
        [SerializeField] private Vector3 _origin;

        /// <summary>
        /// Defines the radius of the circle.
        /// </summary>
        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// Defines the origin of the circle.
        /// </summary>
        public Vector3 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        /// <inheritdoc />
        /// <summary>
        /// Will render the circle.
        /// </summary>
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