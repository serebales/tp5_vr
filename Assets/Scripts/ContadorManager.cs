using UnityEngine;
using TMPro;

public class ContadorManager : MonoBehaviour
{
    public int contador = 0;
    public TextMeshProUGUI textoContador;
    public GameObject cartelVictoria;  // Cartel parcial (por ronda)
    public GameObject cartelGanaste;   // Cartel final ("¡Ganaste!")

    public float tiempoParaReset = 6f; // Tiempo antes de reiniciar el contador

    public int maxRondas = 2;
    private int rondasCompletadas = 0;

    private void Start()
    {
        ActualizarTexto();

        if (cartelVictoria != null)
            cartelVictoria.SetActive(false);

        if (cartelGanaste != null)
            cartelGanaste.SetActive(false);
    }

    public void Sumar()
    {
        contador++;
        ActualizarTexto();

        if (contador == 8)
        {
            rondasCompletadas++;

            if (rondasCompletadas < maxRondas)
            {
                MostrarCartelYResetear(); // Cartel parcial
            }
            else
            {
                MostrarCartelGanaste(); // Cartel final
            }
        }
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

        // Reactivamos todos los objetos que pueden volver a sumar
        SumarAlTocar[] objetos = FindObjectsOfType<SumarAlTocar>();
        foreach (var obj in objetos)
        {
            obj.Resetear();
            obj.gameObject.SetActive(true);
        }
    }

    private void MostrarCartelGanaste()
    {
        if (cartelGanaste != null)
            cartelGanaste.SetActive(true);

        if (textoContador != null)
            textoContador.gameObject.SetActive(false);

        if (cartelVictoria != null)
            cartelVictoria.SetActive(false);

        // Desactivamos todos los objetos que suman
        SumarAlTocar[] objetos = FindObjectsOfType<SumarAlTocar>();
        foreach (var obj in objetos)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
