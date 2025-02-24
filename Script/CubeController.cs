using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento
    public float rotationSpeed = 50f; // Velocidad de rotación



    private void Update()
    {
        /* 
         
             // Movimiento constante hacia adelante en cada frame
             transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

             // Rotación en Update (afectada por los FPS)
             transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        */

        if (Input.GetKey(KeyCode.R)) // Si presionas R, rota
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }


    }

    private void FixedUpdate()
    {
        // Rotación en FixedUpdate (más consistente con la física)
        transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime);
    }
}
