using Player;
using UI.Popups;

namespace Game.States
{
    public class MainMenuState : IGameState
    {
        private readonly PlayerController _player;
        private readonly MainMenuPopup _mainMenuPopup;

        public MainMenuState(PlayerController player, MainMenuPopup mainMenuPopup)
        {
            _player = player;
            _mainMenuPopup = mainMenuPopup;
        }

        public void Enter()
        {
            _player.SetIdle();
            _mainMenuPopup.ShowView(); // показуємо головне меню
        }

        public void Exit()
        {
            _mainMenuPopup.HideView(); // ховаємо головне меню
        }

        public void Update()
        {
        }
    }
}