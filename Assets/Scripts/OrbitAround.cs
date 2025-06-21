using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        // Orbita alrededor del punto (0,0,0), sobre el eje Y del mundo
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
