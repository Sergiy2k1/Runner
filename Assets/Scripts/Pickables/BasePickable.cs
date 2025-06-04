using DG.Tweening;
using Game;
using UnityEngine;

namespace Pickables
{
    [RequireComponent(typeof(Collider))]
    public abstract class BasePickable : MonoBehaviour, IPickable
    {
        [Header("Idle Animation")]
        [SerializeField] private float rotationSpeed = 50f;
        [SerializeField] private float floatAmplitude = 0.25f;
        [SerializeField] private float floatFrequency = 1f;

        [Header("Visual")]
        [SerializeField] private Transform _visual; 

        private Vector3 _startPos;

        private void Start()
        {
            _startPos = _visual.position;
            AnimateRotation();
            AnimateFloating();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerTriggerObserver observer))
            {
                PickUp(other.gameObject);
            }
        }

        public void PickUp(GameObject collector)
        {
            OnPickUp(collector);
            PlayPickUpEffect();
        }

        protected abstract void OnPickUp(GameObject collector);

        protected virtual void PlayPickUpEffect()
        {
            _visual
                .DOScale(Vector3.zero, 0.15f)
                .SetEase(Ease.InBack)
                .OnComplete(() => Destroy(gameObject));
        }

        private void AnimateRotation()
        {
            _visual
                .DORotate(new Vector3(0, 360, 0), 360f / rotationSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }

        private void AnimateFloating()
        {
            _visual
                .DOMoveY(_startPos.y + floatAmplitude, floatFrequency / 2f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }
}