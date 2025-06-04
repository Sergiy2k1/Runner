using Audio;
using Const;
using UnityEngine;

namespace Pickables
{
    public class Coin : BasePickable
    {
         private int value = 1;

        protected override void OnPickUp(GameObject collector)
        {
            if (collector.TryGetComponent(out CollectibleManager manager))
            {
                manager.AddCoins(value);
            }
        }

        protected override void PlayPickUpEffect()
        {
            AudioManager.Instance.PlaySFX(AudioConst.CoinColection);
            base.PlayPickUpEffect();
        }
    }
}