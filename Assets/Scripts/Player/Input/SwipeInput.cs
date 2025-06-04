using UnityEngine;

namespace Player
{
    public class SwipeInput : ILaneInput
    {
        private Vector2 _startTouchPosition;
        private Vector2 _endTouchPosition;
        private bool _swipeProcessed = false;

        private int _laneChange = 0;
        private bool _jumpRequested = false;

        private float _minSwipeDistance = 50f;

        public int GetLaneChange()
        {
            HandleSwipe();
            int result = _laneChange;
            _laneChange = 0;
            return result;
        }

        public bool JumpRequested()
        {
            bool result = _jumpRequested;
            _jumpRequested = false; 
            return result;
        }

        private void HandleSwipe()
        {
            if (Input.touchCount == 0)
                return;

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
                _swipeProcessed = false;
            }

            if (touch.phase == TouchPhase.Ended && !_swipeProcessed)
            {
                _endTouchPosition = touch.position;
                Vector2 delta = _endTouchPosition - _startTouchPosition;

                if (delta.magnitude >= _minSwipeDistance)
                {
                    float x = delta.x;
                    float y = delta.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        _laneChange = x > 0 ? 1 : -1;
                    }
                    else
                    {
                        _jumpRequested = y > 0;
                    }

                    _swipeProcessed = true;
                }
            }
        }
    }
}