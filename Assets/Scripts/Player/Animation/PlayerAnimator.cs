using Player.Const;
using UnityEngine;

namespace Player.Animation
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private PlayerState _currentState;

        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetState(PlayerState newState)
        {
            if (_currentState == newState) return;

            _currentState = newState;
            
            _animator.SetBool(IsRunning, false);
            _animator.SetBool(IsJumping, false);
            _animator.SetBool(IsFalling, false);
            
            switch (newState)
            {
                case PlayerState.Idle:
                    break;

                case PlayerState.Running:
                    _animator.SetBool(IsRunning, true);
                    break;

                case PlayerState.Jumping:
                    _animator.SetBool(IsJumping, true);
                    break;

                case PlayerState.Falling:
                    _animator.SetBool(IsFalling, true);
                    break;
            }
        }
    }
}