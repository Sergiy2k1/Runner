using UnityEngine;

namespace CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _player;

        [Header("Camera Settings")]
        [SerializeField] private Vector3 _baseOffset = new Vector3(0f, 5f, -10f);
        [SerializeField] private float _smoothSpeed = 5f;

        [Header("Dynamic X Shifts")]
        [SerializeField] private float _laneShiftAmount = 5.5f;
        [SerializeField] private float _laneThreshold = 1.7f;

        private Vector3 _currentVelocity;

        private void LateUpdate()
        {
            if (_player == null) return;

            FollowPlayer();
        }

        private void FollowPlayer()
        {
            Vector3 targetOffset = _baseOffset;
            targetOffset.x = GetDynamicXOffset(_player.position.x);

            Vector3 targetPosition = new Vector3(0f, _player.position.y, _player.position.z) + targetOffset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(23.17f, 0f, 0f);
        }

        private float GetDynamicXOffset(float playerX)
        {
            if (playerX > _laneThreshold)
                return _laneShiftAmount;

            if (playerX < -_laneThreshold)
                return -_laneShiftAmount;

            return 0f;
        }
    }
}