using Assets.Scripts;
using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class Green : MonoBehaviour
{
    MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void On()
    {
        meshRenderer.material.color = Color.green;
    }
    public void Off()
    {
        meshRenderer.material.color = Color.white;
    }
}
