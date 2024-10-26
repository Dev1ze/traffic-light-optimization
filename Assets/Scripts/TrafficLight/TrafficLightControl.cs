using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour, IObservable<bool>
{
	[SerializeField]
	private bool switcher;
	public bool Switcher
	{
		get { return switcher; }
		set 
        { 
            switcher = value;
            Notify(switcher);
        }
	}
	private List<IObserver<bool>> observers = new List<IObserver<bool>>();

    public IDisposable Subscribe(IObserver<bool> observer)
    {
        observers.Add(observer);
        return new Subscribers(observers, observer);
    }

    private void Notify(bool value)
    {
        if(observers != null)
        {
            foreach (IObserver<bool> observer in observers)
            {
                observer.OnNext(value);
            }
        }
    }

    private void OnValidate()
    {
        Switcher = switcher;
    }
}
