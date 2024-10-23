using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour
{
    [SerializeField]
    private bool green;
    Transform[] Lights;
    Green greenLight;
    Red redLight;
    void Start()
    {
        Lights = transform.GetComponentsInChildren<Transform>();
        greenLight = Lights[1].GetComponent<Green>();
        redLight = Lights[3].GetComponent<Red>();
    }

    void Update()
    {
        if (green)
        {
            greenLight.On();
            redLight.Off();
        }
        else
        {
            greenLight.Off();
            redLight.On();
        }
    }
}
