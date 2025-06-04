using UnityEngine;
using Player.Animation;
using Player.States;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Forward Movement")]
        [SerializeField] private float _forwardSpeed = 5f;

        [Header("Lane Switching")]
        [SerializeField] private float _laneOffset = 2f;
        [SerializeField] private float _laneSwitchSpeed = 10f;

        [Header("Jump")]
        [SerializeField] private LayerMask _groundMask;
        
        private PlayerStateMachine _stateMachine;
        public PlayerStateMachine StateMachine => _stateMachine;
        
        private Rigidbody _rb;
        private ILaneInput _input;
        private ForwardMover _forwardMover;
        private LaneSwitcher _laneSwitcher;
        private Jumper _jumper;
        private PlayerAnimator _playerAnimator;

        private bool _canMove;
       

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _input = new CombinedInput();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _stateMachine = new PlayerStateMachine();

            _forwardMover = new ForwardMover(transform, _forwardSpeed, _stateMachine, _playerAnimator);
            _laneSwitcher = new LaneSwitcher(transform, _laneOffset, _laneSwitchSpeed);
            _jumper = new Jumper(transform, GetComponent<CapsuleCollider>(), _stateMachine, _playerAnimator);
            
        }

        private void Update()
        {
            if (!_canMove) return;
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
            
            _stateMachine.Update();
            
        }
        public void SetIdle()
        {
            _stateMachine.SetState(new IdleStateAnimation(_playerAnimator));
        }

        public void EnableMovement(bool enable)
        {
            _canMove = enable;
        }

    }
}
