using System;

using UnityEngine;
namespace Assets.Scripts.Entities.Player.Animation
{
    public class AnimationManager : Player
    {
        HorizontalMovement horizontalMove;
        Jumping jumping;
        Animator anim;
        [field: SerializeField] public AnimationState AnimationState { get; private set; }
        public event Action<AnimationState> OnMove;
        public override void Start()
        {
            base.Start();
            horizontalMove = GetComponent<HorizontalMovement>();
            jumping = GetComponent<Jumping>();
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
            if (jumping.IsJumping == true)
                AnimationState = rb.velocityY > 0 ? AnimationState.Jump : AnimationState.Fall;
            else if (jumping.IsGrounded == true)
                AnimationState = horizontalMove.IsMove ? AnimationState.Run : AnimationState.Idle;
            else
                AnimationState = AnimationState.Fall;
        }
    }
}

