using UnityEngine;

namespace WeersProductions.ArcTools
{
    [RequireComponent(typeof(LineRenderer))]
    public class ShapeRenderer : MonoBehaviour
    {
        protected LineRenderer LineRenderer;

        [SerializeField] private int _resolution = 2;

        public int Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        private void Awake()
        {
            LineRenderer = GetComponent<LineRenderer>();
        }

        public virtual void Render()
        {

        }

        private void OnValidate()
        {
            _resolution = Mathf.Max(2, _resolution);
        }

        protected void ApplyPositions(Vector3[] positions)
        {
            LineRenderer.positionCount = positions.Length;
            LineRenderer.SetPositions(positions);
        }
    }
}