using System;

using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Jumping : Player
    {
        [SerializeField] private float _jumpImpulse;
        [SerializeField] private float _jumpRadius;
        [SerializeField] private Transform _footPos;
        [SerializeField] private LayerMask _groundMask;
        [field: SerializeField] public bool IsGrounded { get; private set; }
        [field: SerializeField] public bool IsJumping { get; private set; }
        public void Jump()
        {
            float y = Input.GetAxisRaw("Vertical") * _jumpImpulse * Time.fixedDeltaTime;
            if (CanJump() && y > 0)
            {
                rb.velocity = new Vector2(rb.velocityX, y);
                IsJumping = true;
            }
        }
        private bool CanJump()
        {
            IsGrounded = Physics2D.OverlapCircle(_footPos.position, _jumpRadius, _groundMask);
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
