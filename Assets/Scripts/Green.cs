using Assets.Scripts;
using System;
using UnityEngine;

public class Green : MonoBehaviour, IObserver<bool>
{
    MeshRenderer meshRenderer; // Компонент на обьекте который хранит в себе материал 
    TrafficLightControl trafficLightControl;
    IDisposable unsubscribe;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        trafficLightControl = GetComponentInParent<TrafficLightControl>();
        unsubscribe = trafficLightControl.Subscribe(this);
    }

    void OnDisable()
    {
        unsubscribe.Dispose();
    }

    public void On()
    {
        meshRenderer.material.color = Color.green;
    }
    public void Off()
    {
        meshRenderer.material.color = Color.white;
    }

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
        Debug.LogError(error);
    }

    public void OnNext(bool value)
    {
        if (value)
        {
            On();
        }
        else
        {
            Off();
        }
    }
}
