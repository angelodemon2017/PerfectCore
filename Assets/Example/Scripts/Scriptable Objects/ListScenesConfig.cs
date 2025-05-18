using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelsConfig")]
public class LevelsConfig : ScriptableObject
{
    [SerializeField] private List<LevelConfig> _levels;

    public IReadOnlyList<ILevelConfig> Levels => _levels;

    public ILevelConfig GetLevelByNumber(int levelNumber)
    {
        return _levels.Find(level => level.LevelNumber == levelNumber);
    }
}
