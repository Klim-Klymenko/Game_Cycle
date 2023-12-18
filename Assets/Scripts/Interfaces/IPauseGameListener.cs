namespace GameCycle
{
    public interface IPauseGameListener : IGameListener
    {
        void OnPause();
    }
}