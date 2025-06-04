using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class WinPopup : BasePopup
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton;
        
        private void OnEnable() => 
            Subscription();

        private void OnDisable() => 
            Unsubscribe();
        
        
        private void Subscription()
        {
            restartButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(QuitGame);
        }

        private void Unsubscribe()
        {
            restartButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }

        private void Restart()
        {
            _gameManager.RestartGame();
        }


        private void QuitGame()
        {
            _gameManager.ExitGame();
        }
    }
}