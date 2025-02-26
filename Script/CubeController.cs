using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 2f;        // Velocidad de movimiento hacia adelante
    public float rotationSpeed = 100f;  // Velocidad de rotación manual

    private bool rotateX = false; // Variable para activar rotación en X

    void Update()
    {
        // Movimiento automático hacia adelante
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotación en el eje Y (Update, dependiente de FPS) con la tecla D
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Detectar si la tecla A está presionada para rotar en X
        rotateX = Input.GetKey(KeyCode.A);
    }

    void FixedUpdate()
    {
        // Aplicar rotación en X en FixedUpdate si la tecla A está presionada
        if (rotateX)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
