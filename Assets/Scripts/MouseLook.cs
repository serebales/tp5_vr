using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;  // Sensibilidad del mouse
    float xRotation = 0f;                  // Acumulador para la rotación vertical

    void Start()
    {
        // Mostrar el cursor y permitir que se mueva libremente (modo test)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Capturar movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar la cámara hacia arriba/abajo (limitado a 90 grados)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplicar rotación vertical a la cámara (eje X)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar horizontalmente el padre de la cámara (eje Y)
        if (transform.parent != null)
        {
            transform.parent.Rotate(Vector3.up * mouseX);
        }
    }
}
