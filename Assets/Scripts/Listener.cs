using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    [SerializeField] private BoolEvent _onOpenDoorEvent;
    [SerializeField] private Vector3Event _onTestEvent;
    [SerializeField] private PlayerEvent _onPlayerEvent;

    private void OnEnable()
    {
        _onOpenDoorEvent.AddListener(OnOpenDoor);
        _onTestEvent.AddListener(OnTestEvent);
        _onPlayerEvent.AddListener(OnPlayerEvent);
    }
    
    private void OnDisable()
    {
        _onOpenDoorEvent.RemoveListener(OnOpenDoor);
        _onTestEvent.RemoveListener(OnTestEvent);
        _onPlayerEvent.RemoveListener(OnPlayerEvent);
    }

    private void OnPlayerEvent(PlayerData value)
    {
        Debug.Log($"Health: {value.Health}");
        Debug.Log($"Name: {value.Name}");
    }

    private void OnTestEvent(Vector3 value)
    {
        Debug.Log($"Vector3 is: {value}");
    }


    private void OnOpenDoor(bool value)
    {
        Debug.Log($"Value is : {value}");
    }
}
