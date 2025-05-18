using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
public class LevelConfig : ScriptableObject, ILevelConfig
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private string _levelName;
    [SerializeField] private SceneAsset _scene;

    public int LevelNumber => _levelNumber;
    public string LevelName => _levelName;
    public string Scene => _scene.name;
}