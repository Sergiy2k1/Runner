using Player;
using Player.Animation;
using Player.Const;
using Player.States;
using UI.Popups;

namespace Game.States
{
    public class GameOverState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly PlayerAnimator _playerAnimator;
        private readonly LosePopup _losePopup;

        public GameOverState(PlayerStateMachine playerStateMachine, PlayerAnimator animator, LosePopup losePopup)
        {
            _playerStateMachine = playerStateMachine;
            _playerAnimator = animator;
            _losePopup = losePopup;
        }

        public void Enter()
        {
            _playerStateMachine.SetState(new LoseStateAnimation(_playerAnimator));

            _losePopup.ShowView();
        }

        public void Exit()
        {
            _losePopup.HideView();
        }

        public void Update()
        {
        }
    }
}