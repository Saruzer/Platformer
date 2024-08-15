using UnityEngine;

namespace Assets.Scripts.Entities
{
    public abstract class Jump : Entity
    {
        [SerializeField] protected Color _gizmosColor;
        [SerializeField] protected float _jumpImpulse;
        [SerializeField] protected Transform _target;
        [SerializeField] protected LayerMask _collideMask;
        [SerializeField] protected Rect _collideRect;

        [field: SerializeField] public bool IsCollide { get; protected set; }
        [field: SerializeField] public bool IsUnlimitedJumps { get; set; }


        protected virtual void PerformJump()
        {
            rb.velocity = new Vector2(rb.velocityX, _jumpImpulse * Time.fixedDeltaTime);
        }
        public abstract bool CanJump();

        protected virtual void CheckCollision()
        {
            IsCollide = Physics2D.OverlapBox(_target.position, _collideRect.size, 0, _collideMask);
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawCube(new Vector3(_target.position.x, _target.position.y, 0.01f),
                            new Vector3(_collideRect.size.x, _collideRect.size.y, 0.01f));
        }
    }
}
