using Pickables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class LosePopup : BasePopup
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton;
        
        [Header("Coin Info")]
        [SerializeField] private TextMeshProUGUI _coinText;
        
        [SerializeField] private CollectibleManager _collectibleManager;

        private void OnEnable()
        {
            Subscription();
        }

        private void OnDisable() =>
            Unsubscribe();


        public override void ShowView()
        {
            base.ShowView();
            UpdateCoinDisplay();
        }
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
        
        private void UpdateCoinDisplay()
        {
            if (_collectibleManager != null && _coinText != null)
            {
                _coinText.text = $"Coins Collected: {_collectibleManager.Coins}";
            }
        }
    }
}