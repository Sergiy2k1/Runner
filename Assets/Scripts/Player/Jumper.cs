using UnityEngine;
using DG.Tweening;
using Player.States;
using Player.Animation;

namespace Player
{
    public class Jumper
    {
        private readonly Transform _transform;
        private readonly CapsuleCollider _collider;
        private readonly PlayerStateMachine _stateMachine;
        private readonly PlayerAnimator _animator;
        private readonly float _jumpHeight;
        private readonly float _jumpDuration;
        private readonly float _fallDuration;

        private readonly float _defaultColliderHeight;
        private readonly float _reducedColliderHeight = 3.0f;

        private bool _isJumping;

        public Jumper(Transform transform, CapsuleCollider collider, PlayerStateMachine stateMachine, PlayerAnimator animator,
                      float jumpHeight = 4.1f, float jumpDuration = 0.3f, float fallDuration = 0.25f)
        {
            _transform = transform;
            _collider = collider;
            _stateMachine = stateMachine;
            _animator = animator;
            _jumpHeight = jumpHeight;
            _jumpDuration = jumpDuration;
            _fallDuration = fallDuration;

            _defaultColliderHeight = _collider.height;

            _animator.OnJumpAnimationEnd += ResetColliderHeight;
        }

        public void TryJump(bool jumpRequested)
        {
            if (_isJumping || !IsGrounded()) return;

            _isJumping = true;
            ReduceColliderHeight();
            _stateMachine.SetState(new JumpingStateAnimation(_animator, _stateMachine));

            float startY = _transform.position.y;
            float peakY = startY + _jumpHeight;

            Sequence jumpSeq = DOTween.Sequence();

            jumpSeq.Append(_transform.DOMoveY(peakY, _jumpDuration).SetEase(Ease.OutQuad))
                   .Append(_transform.DOMoveY(startY, _fallDuration).SetEase(Ease.InQuad))
                   .OnComplete(() =>
                   {
                       _isJumping = false;
                       ResetColliderHeight();
                   });
        }

        private void ReduceColliderHeight()
        {
            if (_collider != null)
            {
                _collider.height = _reducedColliderHeight;
            }
        }

        private void ResetColliderHeight()
        {
            if (_collider != null)
            {
                _collider.height = _defaultColliderHeight;
            }
        }

        private bool IsGrounded()
        {
            // Optional: Raycast can still be used here if needed
            return Physics.Raycast(_transform.position, Vector3.down, 0.2f);
        }
    }
}
