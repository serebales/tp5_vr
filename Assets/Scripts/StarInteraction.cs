using UnityEngine;

public class StarInteraction : MonoBehaviour
{
    public float gazeTime = 1f; // Tiempo en segundos que el paciente debe mirar
    private float gazeTimer = 0f; // Contador de tiempo
    private bool isGazedAt = false; // Si el jugador está mirando
    private StarManager starManager; // Referencia al administrador de estrellas

    void Awake()
    {
        // Encontrar el StarManager en la escena
        starManager = FindObjectOfType<StarManager>();
        if (starManager == null)
        {
            Debug.LogError("No se encontró StarManager en la escena.");
        }
    }

    void Update()
    {
        if (isGazedAt)
        {
            gazeTimer += Time.deltaTime; // Incrementar el temporizador
            if (gazeTimer >= gazeTime)
            {
                // Desactivar la estrella en lugar de destruirla
                gameObject.SetActive(false);
                // Notificar al StarManager para regenerar esta estrella
                if (starManager != null)
                {
                    starManager.OnStarCollected(this);
                }
                gazeTimer = 0f; // Reiniciar el temporizador
            }
        }
        else
        {
            gazeTimer = 0f; // Reiniciar el temporizador si no se mira
        }
    }

    public void OnGazeEnter()
    {
        isGazedAt = true;
    }

    public void OnGazeExit()
    {
        isGazedAt = false;
    }
}