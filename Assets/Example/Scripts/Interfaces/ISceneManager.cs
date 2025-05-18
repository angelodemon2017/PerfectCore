using System;

namespace Services
{
    public interface ISceneService
    {
        event Action<string> OnLevelLoaded;
        void LoadLevel(int levelNumber);
        ILevelConfig GetCurrentLevelConfig();
    }
}
