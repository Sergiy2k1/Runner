using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Forward Movement")]
        [SerializeField] private float forwardSpeed = 5f;

        [Header("Lane Switching")]
        [SerializeField] private float laneOffset = 2f;
        [SerializeField] private float laneSwitchSpeed = 10f;

        [Header("Jump")]
        [SerializeField] private float jumpForce = 7f;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody _rb;
        private ILaneInput _input;
        private ForwardMover _forwardMover;
        private LaneSwitcher _laneSwitcher;
        private Jumper _jumper;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            
            _input = new CombinedInput();
            
            _forwardMover = new ForwardMover(transform, forwardSpeed);
            _laneSwitcher = new LaneSwitcher(transform, laneOffset, laneSwitchSpeed);
            _jumper = new Jumper(_rb, jumpForce, groundMask);
        }

        private void Update()
        {
            _forwardMover.Move();
            
            int laneChange = _input.GetLaneChange();
            if (laneChange != 0)
            {
                _laneSwitcher.ChangeLane(laneChange);
            }
            
            _laneSwitcher.UpdateLane();
            
            if (_input.JumpRequested())
            {
                _jumper.TryJump(true);
            }
        }
    }
}