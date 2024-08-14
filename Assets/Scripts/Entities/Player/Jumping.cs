using UnityEngine;

namespace Assets.Scripts.Entities.Player
{
    public class Jumping : Player
    {
        [SerializeField] private float _jumpImpulse;
        [SerializeField] private float _jumpRadius;
        [SerializeField] private Transform _footPos;
        [SerializeField] private LayerMask _groundMask;
        [field: SerializeField] public bool IsGrounded { get; private set; }
        [field: SerializeField] public bool IsJumping { get; private set; }
        [field: SerializeField] public bool IsUnlimitedJumps { get; set; }
        private void FixedUpdate()
        {
            Jump();
        }
        public void Jump()
        {
            float y = Input.GetAxisRaw("Vertical");
            IsGrounded = Physics2D.OverlapCircle(_footPos.position, _jumpRadius, _groundMask);
            if(y > 0)
            {
                if (CanJump() || IsUnlimitedJumps)
                {
                    ActiveJump();
                }
            }
        }
        private void ActiveJump()
        {
            rb.velocity = new Vector2(rb.velocityX, _jumpImpulse * Time.fixedDeltaTime);
            IsJumping = true;
        }
        public void InstantJump()
        {
            ActiveJump();
        }
        private bool CanJump()
        {
            if (IsJumping == false)
            {
                return IsGrounded;
            }
            return false;

        }
        public void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Terrain>())
            {
                IsJumping = false;
            }
        }
        #region Gizmoz
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_footPos.position, _jumpRadius);
        }
        #endregion
    }
}
