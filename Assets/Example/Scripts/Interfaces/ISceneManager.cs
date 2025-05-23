using System;

namespace Services
{
    public interface ISceneService
    {
        event Action<int> OnLevelLoaded;
        void LoadLevel(int levelNumber);
        ILevelConfig GetCurrentLevelConfig();
    }
}
