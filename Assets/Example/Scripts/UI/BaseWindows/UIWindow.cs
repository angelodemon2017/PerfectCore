using UnityEngine;
using Zenject;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private bool _isPopup;

    public bool IsPopup => _isPopup;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public class Factory : PlaceholderFactory<UIWindow> { }
}