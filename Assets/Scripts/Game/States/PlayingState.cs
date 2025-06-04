using Player;

namespace Game.States
{
    public class PlayingState : IGameState
    {
        private readonly PlayerController _player;

        public PlayingState(PlayerController player)
        {
            _player = player;
        }

        public void Enter()
        {
            UnityEngine.Time.timeScale = 1f;
            _player.EnableMovement(true);
        }

        public void Exit()
        {
            _player.EnableMovement(false);
        }

        public void Update()
        {
        }
    }
}