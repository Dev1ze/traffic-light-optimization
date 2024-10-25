using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour, IObservable<bool>
{
    private List<IObserver<bool>> lights;
    [SerializeField]
    private bool green;
    public bool MyProperty
    {
        get { return green; }
        set
        {
            green = value;
            Notify(green);
        }
    }

    private void Awake()
    {
        lights = new List<IObserver<bool>>();
    }

    void OnValidate()
    {
        MyProperty = green;
    }

    public void Notify(bool value)
    {
        if (lights != null)
        {
            foreach (IObserver<bool> observer in lights)
            {
                observer.OnNext(value);
            }
        }
    }

    public IDisposable Subscribe(IObserver<bool> observer)
    {
        lights.Add(observer);
        return new Unsubscriber(lights, observer);
    }
}
