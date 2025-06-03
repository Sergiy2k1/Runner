using UnityEngine;
using Player.States;
using Player.Animation;

namespace Player
{
    public class Jumper
    {
        private readonly Rigidbody _rb;
        private readonly float _jumpForce;
        private readonly LayerMask _groundMask;
        private readonly float _groundCheckDistance = 2.2f;
        private readonly PlayerStateMachine _stateMachine;
        private readonly PlayerAnimator _animator;

        public Jumper(Rigidbody rb, float jumpForce, LayerMask groundMask, PlayerStateMachine stateMachine, PlayerAnimator animator)
        {
            _rb = rb;
            _jumpForce = jumpForce;
            _groundMask = groundMask;
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void TryJump(bool jumpRequested)
        {
            Debug.Log($"Jumper jump requested: {IsGrounded()}");
            if (jumpRequested && IsGrounded())
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _stateMachine.SetState(new JumpingState(_animator, _stateMachine));

            }
        }
        

        public bool IsGrounded()
        {
            return Physics.Raycast(_rb.position, Vector3.down, _groundCheckDistance, _groundMask);
        }
    }
}