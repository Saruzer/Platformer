using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class Movement : MonoBehaviour
    {
        [field: SerializeField] public float SmoothTime { get; private set; }
        [field: SerializeField] public Transform Target { get; set; }
        [SerializeField] private float _zOffset = -10;
        private Vector3 velocity;

        public void LateUpdate()
        {
            Move();
        }
        public void Move()
        {
            Vector3 TargetPos = new Vector3(Target.position.x, Target.position.y, _zOffset);
            transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref velocity, SmoothTime);
        }
    }
}
