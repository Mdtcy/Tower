using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalProcesser : IInitializable, IDisposable
{
    // [Inject]
    // private  OnCollideSignal onCollideSignal;
    [Inject]
    readonly SignalBus       signalBus;

    public void Initialize()
    {
        Debug.Log($"VAR initt SignalProcesser");
        signalBus.Subscribe<OnCollideSignal>(OnCollideSignal);
    }

    public void Dispose()
    {
        signalBus.Unsubscribe<OnCollideSignal>(OnCollideSignal);
    }

    private void OnCollideSignal()
    {
        Debug.Log($"VAR OnCollideSignal");
    }
}
