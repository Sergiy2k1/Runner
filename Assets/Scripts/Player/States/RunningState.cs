using Player.Animation;
using UnityEngine;

namespace Player.States
{
    public class RunningState : IPlayerState
    {
        private readonly PlayerAnimator _animator;

        public RunningState(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            Debug.Log("Running state");
            _animator.SetState(Const.PlayerState.Running);
        }

        public void Update() { }

        public void Exit() { }
    }
}