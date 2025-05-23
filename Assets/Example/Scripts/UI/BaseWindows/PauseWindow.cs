using UnityEngine;
using TMPro;

public class PauseWindow : UIWindow
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    public void UpdateView(int counter)
    {
        _textMeshProUGUI.text = $"{counter}";
    }
}