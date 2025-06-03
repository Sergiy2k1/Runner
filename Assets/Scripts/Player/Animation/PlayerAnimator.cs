using UnityEngine;
using System;
using Player.Const;

namespace Player.Animation
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private PlayerState _currentState;

        // Animator parameter hashes
        private static readonly int RunBool = Animator.StringToHash("IsRunning");
        private static readonly int FallBool = Animator.StringToHash("IsFalling");
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");

        // Event to notify when jump animation finishes
        public event Action OnJumpAnimationEnd;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetState(PlayerState newState)
        {
            if (_currentState == newState)
                return;

            _currentState = newState;

            // Reset bools
            _animator.SetBool(RunBool, false);
            _animator.SetBool(FallBool, false);

            // Handle animator state transitions
            switch (newState)
            {
                case PlayerState.Running:
                    _animator.SetBool(RunBool, true);
                    break;

                case PlayerState.Falling:
                    _animator.SetBool(FallBool, true);
                    break;

                case PlayerState.Jumping:
                    _animator.SetTrigger(JumpTrigger); // trigger will re-enter even if already playing
                    break;

                case PlayerState.Idle:
                    // Do nothing for now
                    break;
            }
        }

        // Called from Animation Event at the end of Jump clip
        public void OnJumpEnd()
        {
            Debug.Log("Jump animation finished → event fired");
            OnJumpAnimationEnd?.Invoke();
        }
    }
}