using Player.Animation;
using Player.Const;
using UnityEngine;

namespace Player.States
{
    public class RunningStateAnimation : IPlayerState
    {
        private readonly PlayerAnimator _animator;

        public RunningStateAnimation(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            Debug.Log("Running state");
            _animator.SetState(PlayerState.Running);
        }

        public void Update() { }

        public void Exit() { }
    }
}