using UnityEngine;
using Zenject;

public class TestPoolObject : MonoBehaviour, IPoolable<IMemoryPool>
{
    public int Counter;

    private IMemoryPool _pool;

    public void OnDespawned()
    {
        _pool = null;
        gameObject.SetActive(false);
    }

    public void OnSpawned(IMemoryPool pool)
    {
        _pool = pool;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        _pool?.Despawn(this);
    }

    public class Pool : MonoPoolableMemoryPool<IMemoryPool, TestPoolObject> { }

    public class Factory : PlaceholderFactory<TestPoolObject> { }
}