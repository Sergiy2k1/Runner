using Game;
using UnityEngine;

namespace Obstacles
{
    public abstract class BaseObstacle : MonoBehaviour
    {
        protected abstract void OnPlayerHit(IGameLoseHandler player);

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IGameLoseHandler player))
            {
                OnPlayerHit(player);
            }
        }
    }
}