namespace Player
{
    public class CombinedInput : ILaneInput
    {
        private readonly ILaneInput _keyboardInput;
        private readonly ILaneInput _swipeInput;

        public CombinedInput()
        {
            _keyboardInput = new LaneInputKeyboard();
            _swipeInput = new SwipeInput();
        }

        public int GetLaneChange()
        {
            int swipe = _swipeInput.GetLaneChange();
            int keyboard = _keyboardInput.GetLaneChange();

            return swipe != 0 ? swipe : keyboard;
        }

        public bool JumpRequested()
        {
            return _swipeInput.JumpRequested() || _keyboardInput.JumpRequested();
        }
    }
}