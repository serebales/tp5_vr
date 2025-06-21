using UnityEngine;

public class FlotacionEspacial : MonoBehaviour
{
    public float amplitud = 0.5f;     // Qué tanto se mueve arriba/abajo
    public float frecuencia = 1f;     // Qué tan rápido se mueve
    public float rotacionVel = 10f;   // Velocidad de rotación opcional

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento vertical oscilante
        float nuevaY = Mathf.Sin(Time.time * frecuencia) * amplitud;
        transform.position = posicionInicial + new Vector3(0, nuevaY, 0);

        // Rotación lenta para más realismo (opcional)
        transform.Rotate(Vector3.up * rotacionVel * Time.deltaTime);
    }
}