using System;

using UnityEngine;
namespace Assets.Scripts.Entities.Player.Animation
{
    public class AnimationManager : Entity
    {
        HorizontalMovement horizontalMove;
        WallJump wallJump;
        VerticalJump jumping;
        Animator anim;
        [field: SerializeField] public AnimationState AnimationState { get; private set; }
        public event Action<AnimationState> OnMove;
        public override void Start()
        {
            base.Start();
            horizontalMove = GetComponent<HorizontalMovement>();
            jumping = GetComponent<VerticalJump>();
            wallJump = GetComponent<WallJump>();
            anim = GetComponent<Animator>();
        }
        private void Update()
        {
            OnMove?.Invoke(AnimationState);

            ChangeAnimation(AnimationState);

            UpdatePlayerState();
        }
        public void ChangeAnimation(AnimationState animation)
        {
            anim.SetInteger("State", (int)animation);
        }
        private void UpdatePlayerState()
        {
            if(wallJump.IsCollide && wallJump.IsHolding)
            {
                AnimationState = AnimationState.WallJump;
                return;
            }
            if (jumping.IsFlying == true)
                AnimationState = rb.velocityY > 0 ? AnimationState.Jump : AnimationState.Fall;
            else if (jumping.IsCollide == true)
                AnimationState = horizontalMove.IsMove ? AnimationState.Run : AnimationState.Idle;
            else
                AnimationState = AnimationState.Fall;
        }
    }
}

