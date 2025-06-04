namespace Player
{
    public interface ILaneInput
    {
        int GetLaneChange(); // -1 = ліво, 1 = право, 0 = нічого
        bool JumpRequested();
    }
}
