using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class MainMenuPopup  : BasePopup
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        
        private void OnEnable() => 
            Subscription();

        private void OnDisable() => 
            Unsubscribe();

        private void Subscription()
        {
            playButton.onClick.AddListener(PlayLevel);
            exitButton.onClick.AddListener(QuitGame);
        }

        private void Unsubscribe()
        {
            playButton.onClick.RemoveAllListeners();
        }

        private void PlayLevel()
        {
            _gameManager.StartGame();
        }
        private void QuitGame()
        {
            _gameManager.ExitGame();
        }
        
    }
}