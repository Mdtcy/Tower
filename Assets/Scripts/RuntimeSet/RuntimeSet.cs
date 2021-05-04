using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public abstract class RuntimeSet<T> : ScriptableObject
{
    [ShowInInspector, ReadOnly]
    private List<T> items = new List<T>();

    public List<T> Items => items;

    public void Initialize()
    {
        items.Clear();
    }

    public T GetItemIndex(int index)
    {
        return items[index];
    }

    public void AddToList(T thingToAdd)
    {
        if (!items.Contains(thingToAdd))
        {
            items.Add(thingToAdd);
        }
    }

    public void RemoveToList(T thingToRemove)
    {
        if (items.Contains(thingToRemove))
        {
            items.Remove(thingToRemove);
        }
    }

    // public T this[int index]
    // {
    //     get => items[index];
    //     set => items[index] = value;
    // }
}

