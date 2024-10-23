using UnityEngine;

public class Green : MonoBehaviour
{
    MeshRenderer meshRenderer;
    void Awake()
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
