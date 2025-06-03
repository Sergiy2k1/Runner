using Player.Animation;
using UnityEngine;

namespace Player.States
{
    public class FallingState : IPlayerState
    {
        private readonly PlayerAnimator _animator;

        public FallingState(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            Debug.Log("ENTER STATE: falling");
            _animator.SetState(Const.PlayerState.Falling);
        }

        public void Update() { }

        public void Exit() { }
    }
}