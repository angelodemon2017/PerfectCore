using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIService : IInitializable
{
    [Inject] private DiContainer _container;
    private WindowsConfig _windowsConfig;
    private Canvas _rootCanvas;

    private Dictionary<Type, UIWindow> _openedWindows = new Dictionary<Type, UIWindow>();
    private Stack<UIWindow> _windowStack = new Stack<UIWindow>();

    public Transform GetUIParent => _rootCanvas.transform;

    public UIService(WindowsConfig windowsConfig)
    {
        _windowsConfig = windowsConfig;
        _rootCanvas = GameObject.Instantiate(_windowsConfig.MainCanvas);
        GameObject.DontDestroyOnLoad(_rootCanvas);
    }

    public void Initialize()
    {

    }

    public TState ChangeWindow<TState>() where TState : UIWindow
    {
        foreach (var window in _openedWindows.Values)
        {
            if (!window.IsPopup)
            {
                window.Hide();
            }
        }
        var nextWindow = _container.Resolve<TState>();
        nextWindow.transform.SetParent(_rootCanvas.transform, false);
        ShowWindow<UIWindow>(nextWindow);
        return nextWindow;
    }

    public void ShowWindow<T>(UIWindow window) where T : UIWindow
    {
        if (_windowStack.Count > 0 && !_windowStack.Peek().IsPopup)
        {
            _windowStack.Pop().Hide();
        }

        window.Show();
        _windowStack.Push(window);

        if (!_openedWindows.ContainsKey(typeof(T)))
        {
            _openedWindows.Add(typeof(T), window);
        }
    }

    public void CloseTopWindow()
    {
        if (_windowStack.Count > 0)
        {
            var window = _windowStack.Pop();
            window.Hide();
        }
    }
}