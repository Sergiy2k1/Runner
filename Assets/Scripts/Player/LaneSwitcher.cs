using UnityEngine;

namespace Player
{
    public class LaneSwitcher
    {
        private readonly Transform _transform;
        private readonly float _laneOffset;
        private readonly float _switchSpeed;

        private Lane _currentLane = Lane.Center;
        private float _targetX;

        public LaneSwitcher(Transform transform, float laneOffset, float switchSpeed)
        {
            _transform = transform;
            _laneOffset = laneOffset;
            _switchSpeed = switchSpeed;
            SetTargetX();
        }

        public void ChangeLane(int direction)
        {
            int newLane = Mathf.Clamp((int)_currentLane + direction, -1, 1);
            _currentLane = (Lane)newLane;
            SetTargetX();
        }

        private void SetTargetX()
        {
            _targetX = (int)_currentLane * _laneOffset;
        }

        public void UpdateLane()
        {
            Vector3 pos = _transform.position;
            float newX = Mathf.Lerp(pos.x, _targetX, Time.deltaTime * _switchSpeed);
            _transform.position = new Vector3(newX, pos.y, pos.z);
        }
    }
}