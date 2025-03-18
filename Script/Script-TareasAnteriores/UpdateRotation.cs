using UnityEngine;

public class UpdateRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Velocidad de rotacion

    void Update()
    {
        // Rotacion en el eje Y (Update, dependiente de FPS) con la tecla D
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
