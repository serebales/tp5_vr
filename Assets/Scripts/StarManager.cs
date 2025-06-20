using UnityEngine;
using TMPro; // Necesario para TextMeshPro
using System.Collections.Generic;

public class StarManager : MonoBehaviour
{
    public List<StarInteraction> stars; // Lista de todas las estrellas
    public float respawnDelay = 2f; // Tiempo antes de que reaparezca una estrella
    public float respawnRadius = 1f; // Radio alrededor de la posición inicial para reaparecer
    public TextMeshProUGUI collectedText; // Texto UI para el contador
    private Dictionary<StarInteraction, Vector3> initialPositions; // Posiciones iniciales
    private int collectedStars = 0; // Contador de estrellas colectadas

    void Start()
    {
        // Inicializar el diccionario de posiciones iniciales
        initialPositions = new Dictionary<StarInteraction, Vector3>();

        // Opcional: Buscar estrellas si no están asignadas manualmente
        if (stars == null || stars.Count == 0)
        {
            stars = new List<StarInteraction>(FindObjectsOfType<StarInteraction>());
        }

        // Guardar las posiciones iniciales y activar todas las estrellas
        foreach (var star in stars)
        {
            initialPositions[star] = star.transform.position;
            star.gameObject.SetActive(true);
        }

        // Actualizar el texto del contador al inicio
        UpdateCounterText();
    }

    public void OnStarCollected(StarInteraction star)
    {
        collectedStars++;
        UpdateCounterText();
        // Iniciar coroutine para reactivar la estrella después de un retraso
        StartCoroutine(RespawnStar(star, respawnDelay));

        // Si todas las estrellas fueron colectadas, reiniciar el juego
        if (collectedStars >= stars.Count)
        {
            ResetGame();
        }
    }

    private void UpdateCounterText()
    {
        if (collectedText != null)
        {
            collectedText.text = $"Estrellas colectadas: {collectedStars}/{stars.Count}";
        }
    }

    private System.Collections.IEnumerator RespawnStar(StarInteraction star, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Obtener la posición inicial de la estrella
        Vector3 initialPosition = initialPositions[star];

        // Generar una nueva posición dentro del radio alrededor de la posición inicial
        Vector3 randomOffset = Random.insideUnitSphere * respawnRadius;
        Vector3 newPosition = initialPosition + randomOffset;

        // Reactivar la estrella en la nueva posición
        star.transform.position = newPosition;
        star.gameObject.SetActive(true);
    }

    private void ResetGame()
    {
        // Reiniciar todas las estrellas
        foreach (var star in stars)
        {
            star.gameObject.SetActive(true);
            // Reposicionar en una posición cercana a la inicial
            Vector3 initialPosition = initialPositions[star];
            Vector3 randomOffset = Random.insideUnitSphere * respawnRadius;
            star.transform.position = initialPosition + randomOffset;
        }
        collectedStars = 0; // Reiniciar el contador
        UpdateCounterText(); // Actualizar el texto
    }
}