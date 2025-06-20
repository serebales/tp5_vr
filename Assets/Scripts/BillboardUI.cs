using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Encontrar la cámara principal del rig de VR
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Hacer que el Canvas mire hacia la cámara
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
    }
}