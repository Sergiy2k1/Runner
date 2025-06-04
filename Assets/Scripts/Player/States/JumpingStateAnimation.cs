using Player.Animation;
using UnityEngine;

namespace Player.States
{
    public class JumpingStateAnimation : IPlayerState
    {
        private readonly PlayerAnimator _animator;
        private readonly PlayerStateMachine _stateMachine;

        public JumpingStateAnimation(PlayerAnimator animator, PlayerStateMachine stateMachine)
        {
            _animator = animator;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("ENTER STATE: Jumping");
            _animator.SetState(Const.PlayerState.Jumping);
            _animator.OnJumpAnimationEnd += HandleJumpEnd;
        }

        public void Exit()
        {
            Debug.Log("EXIT STATE: Jumping");
            _animator.OnJumpAnimationEnd -= HandleJumpEnd;
        }

        public void Update() { }

        private void HandleJumpEnd()
        {
            _stateMachine.SetState(new RunningStateAnimation(_animator));
        }
    }
}