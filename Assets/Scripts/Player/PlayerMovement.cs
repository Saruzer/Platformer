using Assets.Scripts.Player;

using System;

using UnityEngine;

public class PlayerMovement : Player
{
    [Space]

    [SerializeField] private HorizontalMovement _horizontalMove;

    [Space]

    [SerializeField] private Jumping _jumping;

    public static event Action<State> OnMove;
    public override void Start()
    {
        base.Start();
        _horizontalMove = GetComponent<HorizontalMovement>();
        _jumping = GetComponent<Jumping>();
    }
    private void FixedUpdate()
    {
        OnMove?.Invoke(playerState);
        if (_jumping.IsJumping == false && _jumping.IsGrounded == true)
        {
            if (_horizontalMove.IsMove == true)
                playerState = State.Run;
            else
                playerState = State.Idle;
        }
        else if (_jumping.IsJumping == true)
        {
            if (rb.velocityY > 0)
                playerState = State.Jump;
            else
                playerState = State.Fall;
        }
        else
            playerState = State.Fall;

        _horizontalMove.Move();
        _jumping.Jump();
    }
}
