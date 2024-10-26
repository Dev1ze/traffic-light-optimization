using System;
using UnityEngine;

public class Red : MonoBehaviour
{
    MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void On()
    {
        meshRenderer.material.color = Color.red;
    }
    public void Off()
    {
        meshRenderer.material.color = Color.white;
    }
}
