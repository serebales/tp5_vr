using UnityEngine;

public class GazeDetector : MonoBehaviour
{
    public float maxDistance = 10f; // Distancia máxima del raycast
    private StarInteraction lastStar; // Última estrella mirada

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); // Rayo desde la cámara
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            StarInteraction star = hit.collider.GetComponent<StarInteraction>();
            if (star != null)
            {
                if (star != lastStar && lastStar != null)
                {
                    lastStar.OnGazeExit(); // Salir de la estrella anterior
                }
                star.OnGazeEnter(); // Entrar en la nueva estrella
                lastStar = star;
            }
            else if (lastStar != null)
            {
                lastStar.OnGazeExit(); // Salir si no se golpea ninguna estrella
                lastStar = null;
            }
        }
        else if (lastStar != null)
        {
            lastStar.OnGazeExit(); // Salir si no se golpea nada
            lastStar = null;
        }
    }
}