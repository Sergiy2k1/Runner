using System.Collections;
using Game.States;
using Player;
using Player.Animation;
using UI.Popups;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        
        [SerializeField] private MainMenuPopup _mainMenuPopup;
        [SerializeField] private WinPopup _winPopup;
        [SerializeField] private LosePopup _losePopup;
        
        private const string RestartFlagKey = "Restarted";

        private GameStateMachine _stateMachine;
        private PlayerAnimator _playerAnimator;

        private void Awake()
        {
            _playerAnimator = _playerController.GetComponent<PlayerAnimator>();
            _stateMachine = new GameStateMachine();
        }

        private void Start()
        {
            if (PlayerPrefs.GetInt(RestartFlagKey, 0) == 1)
            {
                PlayerPrefs.SetInt("Restarted", 0); 
                _stateMachine.SetState(new PlayingState(_playerController));
            }
            else
            {
                _stateMachine.SetState(new MainMenuState(_playerController, _mainMenuPopup));
            }
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void StartGame()
        {
            _stateMachine.SetState(new PlayingState(_playerController));
        }

        public void RestartGame()
        {
            PlayerPrefs.SetInt(RestartFlagKey, 1);  
            StartCoroutine(LoadSceneAsync());
        }


        public void GameOver()
        {
            _stateMachine.SetState(
                new GameOverState(_playerController.StateMachine, _playerAnimator, _losePopup));
        }


        public void WinGame()
        {
            _stateMachine.SetState(new WinState(_playerController, _winPopup));
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        private IEnumerator LoadSceneAsync()
        {
            var asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}