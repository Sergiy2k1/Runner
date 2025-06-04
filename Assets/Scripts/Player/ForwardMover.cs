using UnityEngine;
using Player.States;
using Player.Animation;

namespace Player
{
    public class ForwardMover
    {
        private readonly Transform _transform;
        private readonly float _speed;
        private readonly PlayerStateMachine _stateMachine;
        private readonly PlayerAnimator _animator;

        private bool _wasRunning = false;

        public ForwardMover(Transform transform, float speed, PlayerStateMachine stateMachine, PlayerAnimator animator)
        {
            _transform = transform;
            _speed = speed;
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void Move()
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);

            if (!_wasRunning)
            {
                _stateMachine.SetState(new RunningStateAnimation(_animator));
                _wasRunning = true;
            }
        }
    }
}