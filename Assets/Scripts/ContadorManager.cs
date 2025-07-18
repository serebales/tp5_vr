using UnityEngine;
using TMPro;

public class ContadorManager : MonoBehaviour
{
    public int contador = 0;
    public TextMeshProUGUI textoContador;
    public GameObject cartelVictoria;

    public float tiempoParaReset = 6f; // tiempo en segundos antes de reiniciar el contador

    public void Sumar()
    {
        contador++;
        ActualizarTexto();

        if (contador == 8)
        {
            MostrarCartelYResetear();
        }
    }

    private void Start()
    {
        ActualizarTexto();
        if (cartelVictoria != null)
            cartelVictoria.SetActive(false);
    }

    private void ActualizarTexto()
    {
        if (textoContador != null)
            textoContador.text = "Contador: " + contador;
    }

    private void MostrarCartelYResetear()
    {
        if (cartelVictoria != null)
            cartelVictoria.SetActive(true);

        if (textoContador != null)
            textoContador.gameObject.SetActive(false);

        Invoke(nameof(ResetearContador), tiempoParaReset);
    }

    private void ResetearContador()
{
    contador = 0;
    ActualizarTexto();

    if (textoContador != null)
        textoContador.gameObject.SetActive(true);

    if (cartelVictoria != null)
        cartelVictoria.SetActive(false);

    //Reseteamos todos los objetos que ya sumaron
    SumarAlTocar[] objetos = FindObjectsOfType<SumarAlTocar>();
    foreach (var obj in objetos)
    {
        obj.Resetear();
    }
}

}


