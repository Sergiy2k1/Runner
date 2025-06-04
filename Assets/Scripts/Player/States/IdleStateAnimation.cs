using Player.Animation;
using Player.Const;
using UnityEngine;

namespace Player.States
{
    public class IdleStateAnimation : IPlayerState
    {
        private readonly PlayerAnimator _animator;

        public IdleStateAnimation(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            Time.timeScale = 1;
            Debug.Log("ENTER STATE: IDle");
            _animator.SetState(PlayerState.Idle);
        }

        public void Update() { }

        public void Exit() { }
    }
}