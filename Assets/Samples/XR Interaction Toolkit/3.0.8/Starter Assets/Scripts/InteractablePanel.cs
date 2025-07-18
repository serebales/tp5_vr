using UnityEngine;
using UnityEngine.EventSystems;

public class InteractablePanel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        StartGame();
    }

    private void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene"); // Cambia por tu escena
    }
}
