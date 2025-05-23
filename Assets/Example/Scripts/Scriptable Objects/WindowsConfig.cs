using UnityEngine;

[CreateAssetMenu(fileName = "WindowsConfig", menuName = "Configs/WindowsConfig")]
public class WindowsConfig : ScriptableObject
{
    public Canvas MainCanvas;

    public LoadingWindow LoadingWindow;
    public MainMenuWindow MenuWindow;
    public PauseWindow PauseWindow;
    public GameplayWindow GameplayWindow;
}