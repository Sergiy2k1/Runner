using UnityEngine;

namespace Game
{
    public class PlayerTriggerObserver : MonoBehaviour, IGameWinHandler,IGameLoseHandler
    {
        [SerializeField] private GameManager _gameManager;

        public void WinGame()
        {
            _gameManager.WinGame();
        }

        public void LoseGame()
        {
            _gameManager.GameOver();
        }
    }
}