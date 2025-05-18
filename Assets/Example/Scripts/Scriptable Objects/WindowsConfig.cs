using UnityEngine;

[CreateAssetMenu(fileName = "WindowsConfig", menuName = "Configs/WindowsConfig")]
public class WindowsConfig : ScriptableObject
{
    public Canvas MainCanvas;

    public MainMenuWindow MenuWindow;
    public PauseWindow PauseWindow;
}