using UnityEngine;

public class GlobalAxisRotate : MonoBehaviour
{
    public float rotationSpeed = 18f; // grados por segundo
    public Vector3 worldAxis = Vector3.up; // eje Y global

    void Update()
    {
        transform.Rotate(worldAxis, rotationSpeed * Time.deltaTime, Space.World);
    }
}
