using Player.Animation;
using UnityEngine;

namespace Player.States
{
    public class IdleState : IPlayerState
    {
        private readonly PlayerAnimator _animator;

        public IdleState(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            Debug.Log("ENTER STATE: IDle");
            _animator.SetState(Const.PlayerState.Idle);
        }

        public void Update() { }

        public void Exit() { }
    }
}