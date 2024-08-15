using UnityEngine;

namespace Assets.Scripts.Entities.Player
{
    public class WallJump : Jump
    {
        [field: SerializeField] public bool IsHolding { get; private set; }
        [SerializeField] private float _holdingStrength;

        [SerializeField] private float _maxYVelocity;
        [SerializeField] private float _minYVelocity;

        [SerializeField] private float _jumpDelay;

        private VerticalJump verticalJump;
        private float jumpDelay;
        private bool isMaxHolding;


        public override void Start()
        {
            base.Start();
            verticalJump = GetComponent<VerticalJump>();
        }

        private void FixedUpdate()
        {
            CheckCollision();
            HandleWallHold();
            HandleWallJump();
            UpdateJumpDelay();
        }
        float x = 0;
        private void HandleWallHold()
        {
            if (CanJump())
            {
                x = Input.GetAxisRaw("Horizontal");

                if (x != 0)
                {
                    if (rb.velocityY >= _minYVelocity && rb.velocityY < _maxYVelocity)
                    {
                        isMaxHolding = true;
                    }

                    if (isMaxHolding == false && rb.velocityY > 0)
                    {
                        rb.velocity = new Vector2(rb.velocityX, rb.velocityY - _holdingStrength * Time.fixedDeltaTime);
                    }
                    else if(isMaxHolding == false && rb.velocityY < 0)
                    {
                        rb.velocity = new Vector2(rb.velocityX, rb.velocityY + _holdingStrength * Time.fixedDeltaTime);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocityX, 0);
                    }

                    IsHolding = true;
                }
                else
                {
                    ResetHold();
                }
            }
            else
            {
                ResetHold();
            }
        }

        private void HandleWallJump()
        {
            if (CanJump())
            {
                float y = Input.GetAxisRaw("Vertical");

                if (y > 0 && (jumpDelay <= 0 || IsUnlimitedJumps) && IsHolding)
                {
                    PerformJump();
                    ResetHold();
                    jumpDelay = _jumpDelay;
                }
            }

        }
        public override bool CanJump()
        {
            return IsCollide && !verticalJump.IsFlying && jumpDelay <= 0;
        }
        private void ResetHold()
        {
            IsHolding = false;
            isMaxHolding = false;
        }

        private void UpdateJumpDelay()
        {
            if (jumpDelay > 0)
            {
                jumpDelay -= Time.fixedDeltaTime;
            }
            else
            {
                jumpDelay = 0;
            }
        }
    }
}
