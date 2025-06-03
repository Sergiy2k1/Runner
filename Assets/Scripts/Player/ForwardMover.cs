using UnityEngine;

namespace Player
{
    public class ForwardMover
    {
        private readonly Transform _transform;
        private readonly float _speed;

        public ForwardMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move()
        {
            _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}