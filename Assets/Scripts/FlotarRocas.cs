using UnityEngine;

public class FlotarRoca : MonoBehaviour
{
    public float amplitud = 0.2f;         // Qué tanto se mueve en cada eje
    public float frecuencia = 0.5f;       // Qué tan rápido se mueve
    public float rotacionVel = 5f;        // Rotación lenta

    private Vector3 posicionInicial;
    private Vector3 fase;

    void Start()
    {
        posicionInicial = transform.position;
        // Fase aleatoria para que no todas las rocas se muevan igual
        fase = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
    }

    void Update()
    {
        float t = Time.time;
        float offsetX = Mathf.Sin(t * frecuencia + fase.x) * amplitud;
        float offsetY = Mathf.Cos(t * frecuencia + fase.y) * amplitud;
        float offsetZ = Mathf.Sin(t * frecuencia + fase.z) * amplitud;

        transform.position = posicionInicial + new Vector3(offsetX, offsetY, offsetZ);

        // Rotación aleatoria suave
        transform.Rotate(Vector3.up * rotacionVel * Time.deltaTime);
    }
}
