using UnityEngine;

namespace Player
{
    public class LaneInputKeyboard : ILaneInput
    {
        public int GetLaneChange()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                return -1;
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                return 1;
            return 0;
        }

        public bool JumpRequested()
        {
            return Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        }
    }
}