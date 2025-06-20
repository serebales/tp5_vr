using UnityEngine;

public class FlotarEstrella : MonoBehaviour
{
    public float amplitud = 0.05f;       // Muy leve movimiento
    public float frecuencia = 1f;        // Oscilación rápida pero suave
    private Vector3 posicionInicial;
    private float fase;

    void Start()
    {
        posicionInicial = transform.position;
        fase = Random.Range(0f, 100f);   // Para que no todas se muevan igual
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * frecuencia + fase) * amplitud;
        transform.position = posicionInicial + new Vector3(0, offsetY, 0);
    }
}
