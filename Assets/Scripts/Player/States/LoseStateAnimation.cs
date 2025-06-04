using Player.Animation;
using Player.Const;
using UnityEngine;

namespace Player.States
{
    public class LoseStateAnimation : IPlayerState
    {
        private readonly PlayerAnimator _animator;

        public LoseStateAnimation(PlayerAnimator animator)
        {
            _animator = animator;
        }

        public void Enter()
        {
            _animator.SetState(PlayerState.Lose);
        }

        public void Update() { }

        public void Exit() { }
    }
}