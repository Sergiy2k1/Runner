using UnityEngine;

namespace Pickables
{
    public interface IPickable
    {
        void PickUp(GameObject collector);
    }
}