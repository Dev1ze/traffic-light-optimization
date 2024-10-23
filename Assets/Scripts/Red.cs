using UnityEngine;

public class Red : MonoBehaviour
{
    MeshRenderer meshRenderer;
    void Awake()
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
