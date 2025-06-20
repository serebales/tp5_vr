using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 30, 0); // grados por segundo

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

