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
        [SerializeField] private float _jumpForce = 7f;
        [SerializeField] private LayerMask _groundMask;

        private Rigidbody _rb;
        private ILaneInput _input;
        private ForwardMover _forwardMover;
        private LaneSwitcher _laneSwitcher;
        private Jumper _jumper;
        private PlayerAnimator _playerAnimator;
        private PlayerStateMachine _stateMachine;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _input = new CombinedInput();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _stateMachine = new PlayerStateMachine();

            _forwardMover = new ForwardMover(transform, _forwardSpeed, _stateMachine, _playerAnimator);
            _laneSwitcher = new LaneSwitcher(transform, _laneOffset, _laneSwitchSpeed);
            _jumper = new Jumper(_rb, _jumpForce, _groundMask, _stateMachine, _playerAnimator);

            // Початковий стан
            _stateMachine.SetState(new IdleState(_playerAnimator));
        }

        private void Update()
        {
            // Рух вперед
            _forwardMover.Move();

            // Стрейф
            int laneChange = _input.GetLaneChange();
            if (laneChange != 0)
            {
                _laneSwitcher.ChangeLane(laneChange);
            }
            _laneSwitcher.UpdateLane();

            // Стрибок (запускає стейт всередині Jumper)
            if (_input.JumpRequested())
            {
                _jumper.TryJump(true);
            }
            
            // Оновлення FSM
            _stateMachine.Update();
        }
    }
}
