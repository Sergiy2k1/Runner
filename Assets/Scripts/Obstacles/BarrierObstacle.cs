using Game;
using UnityEngine;

namespace Obstacles
{
    public class BarrierObstacle : BaseObstacle
    {
        protected override void OnPlayerHit(IGameLoseHandler player)
        {
            player.LoseGame();
        }
    }
}