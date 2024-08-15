using UnityEngine;

namespace Assets.Scripts.Entities.Player
{
    public class VerticalJump : Jump
    {
        [field: SerializeField] public bool IsFlying { get; private set; }
        [SerializeField] private float _jumpQuantity;
        private int jumpCounter = 0;
        private void FixedUpdate()
        {
            CheckCollision();
            HandleJumpInput();
        }

        private void HandleJumpInput()
        {
            float y = Input.GetAxisRaw("Vertical");

            if (y > 0 && (CanJump() || IsUnlimitedJumps || jumpCounter < _jumpQuantity))
            {
                PerformJump();
                IsFlying = true;
            }
        }

        protected override void CheckCollision()
        {
            base.CheckCollision();
            if (IsCollide)
            {
                IsFlying = false;
                jumpCounter = 0;
            }
        }
        protected override void PerformJump()
        {
            base.PerformJump();
            jumpCounter++;
        }
        public override bool CanJump()
        {
            return (!IsFlying && IsCollide);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Terrain>())
            {
                IsFlying = false;
            }
        }
    }
}
