using System;
using UnityEngine;

namespace Pickables
{
    public class CollectibleManager : MonoBehaviour
    {
        private int _coins;

        public int Coins => _coins;
        
        public event Action<int> OnCoinsChanged;

        public void AddCoins(int amount)
        {
            _coins += amount;

            OnCoinsChanged?.Invoke(_coins); 
        }
    }
}