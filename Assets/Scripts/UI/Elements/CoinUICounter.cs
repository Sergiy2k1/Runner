using Pickables;
using TMPro;
using UnityEngine;

namespace UI.Elements
{
    public class CoinUICounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText; 
        [SerializeField] private CollectibleManager _collectibleManager;

        private void OnEnable()
        {
            if (_collectibleManager != null)
                _collectibleManager.OnCoinsChanged += UpdateUI;
        }

        private void OnDisable()
        {
            if (_collectibleManager != null)
                _collectibleManager.OnCoinsChanged -= UpdateUI;
        }
        private void Start()
        {
            UpdateUI(_collectibleManager.Coins);
        }
        

        private void UpdateUI(int newAmount)
        {
            _coinText.text = $"Coins: {newAmount}";
        }
        
    }
}