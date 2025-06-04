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
        
        private static readonly int RunBool = Animator.StringToHash("IsRunning");
        private static readonly int Dancing = Animator.StringToHash("IsDancing");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");
        
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
            
            _animator.SetBool(RunBool, false);
            _animator.SetBool(Hit, false);
            
            switch (newState)
            {
                case PlayerState.Running:
                    _animator.SetBool(RunBool, true);
                    break;

                case PlayerState.Lose:
                    _animator.SetBool(Hit, true);
                    break;

                case PlayerState.Jumping:
                    _animator.SetTrigger(JumpTrigger);
                    break;

                case PlayerState.Idle:
                    _animator.SetBool(Dancing, true);
                    break;
            }
        }
        
        public void OnJumpEnd()
        {
            OnJumpAnimationEnd?.Invoke();
        }
    }
}