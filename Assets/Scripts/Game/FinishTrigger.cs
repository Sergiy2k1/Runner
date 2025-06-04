using UnityEngine;

namespace Game
{
    public class FinishTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IGameWinHandler>(out var winHandler))
            {
                winHandler.WinGame();
            }
        }
    }
}