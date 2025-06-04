using Player;
using Player.Animation;
using UI.Popups;

namespace Game.States
{
    public class WinState : IGameState
    {
        private readonly PlayerController _player;
        private readonly WinPopup _winPopup;

        public WinState(PlayerController player, WinPopup winPopup)
        {
            _player = player;
            _winPopup = winPopup;
        }

        public void Enter()
        {
            _player.EnableMovement(false);
            _player.SetIdle();
            _winPopup.ShowView();
        }

        public void Exit()
        {
            _winPopup.HideView(); 
        }

        public void Update()
        {
        }
    }
}