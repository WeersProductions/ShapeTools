using UnityEngine;

namespace WeersProductions.ArcTools
{
    /// <inheritdoc />
    /// <summary>
    /// Base class of all shapes.
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class ShapeRenderer : MonoBehaviour
    {
        /// <summary>
        /// A reference to the LineRenderer on this GameObject.
        /// </summary>
        protected LineRenderer LineRenderer;

        [SerializeField] private int _resolution = 2;

        /// <summary>
        /// Can be used to define the detail of the shape.
        /// </summary>
        public int Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        private void Awake()
        {
            LineRenderer = GetComponent<LineRenderer>();
        }

        /// <summary>
        /// Override this and render the arc in here.
        /// </summary>
        public virtual void Render()
        {

        }

        /// <summary>
        /// Called in the editor when the gui changes, will make sure the resolution cannot be below 2.
        /// </summary>
        private void OnValidate()
        {
            _resolution = Mathf.Max(2, _resolution);
        }

        /// <summary>
        /// Set the new positions of the LineRenderer.
        /// </summary>
        /// <param name="positions"></param>
        protected void ApplyPositions(Vector3[] positions)
        {
            LineRenderer.positionCount = positions.Length;
            LineRenderer.SetPositions(positions);
        }
    }
}