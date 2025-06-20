using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 20f;

    void Update()
    {
        if (centerPoint != null)
        {
            transform.RotateAround(centerPoint.position, Vector3.up, speed * Time.deltaTime);
        }
    }
}
