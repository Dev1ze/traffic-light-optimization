using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsControl : MonoBehaviour, IObserver<bool>
{
    Green greenLights;
    Red redLights;
    TrafficLightControl trafficLightControl;
    IDisposable subscribe;

    private void Start()
    {
        greenLights = GetComponentInChildren<Green>();
        redLights = GetComponentInChildren<Red>();
        trafficLightControl = GetComponentInParent<TrafficLightControl>();
        subscribe = trafficLightControl.Subscribe(this);
    }
    private void OnDisable()
    {
        subscribe.Dispose();
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        Debug.Log(error);
    }

    public void OnNext(bool value)
    {
        StartCoroutine(LightSwitchCoroutine(value));
    }

    private IEnumerator LightSwitchCoroutine(bool value)
    {
        if (value)
        {
            greenLights.On();
            redLights.Off();
        }
        else
        {
            greenLights.Off();
            yield return new WaitForSeconds(0.5f);
            greenLights.On();
            yield return new WaitForSeconds(0.5f);
            greenLights.Off();
            yield return new WaitForSeconds(0.5f);
            greenLights.On();
            yield return new WaitForSeconds(0.5f);
            greenLights.Off();
            redLights.On();
        }
    }
}
