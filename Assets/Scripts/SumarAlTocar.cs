using UnityEngine;

public class SumarAlTocar : MonoBehaviour
{
    private bool yaSumo = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (yaSumo) return;

        ContadorManager contador = FindObjectOfType<ContadorManager>();
        if (contador != null)
        {
            contador.Sumar();
            yaSumo = true;
        }
    }

    public void Resetear()
    {
        yaSumo = false;
    }
}


