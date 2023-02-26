using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvent<T> : ScriptableObject
{
    private List<Action<T>> _actions = new List<Action<T>>();

    public void AddListener(Action<T> action)
    {
        _actions.Add(action);
    }
    public void RemoveListener(Action<T> action)
    {
        _actions.Remove(action);
    }

    public void Raise(T value)
    {
        foreach (var action in _actions)
        {
            action.Invoke(value);
        }
    }
}
