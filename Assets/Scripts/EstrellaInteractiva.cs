using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EstrellaInteractiva : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Debug.Log("¡Estrella capturada!");
        Destroy(gameObject); // Desaparece la estrella
    }
}

