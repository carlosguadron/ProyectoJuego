using UnityEngine;

public class BallController : MonoBehaviour
{
    public float launchForce = 10f; // Fuerza del lanzamiento
    private Rigidbody rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLaunched) // Lanza la bola con clic izquierdo
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        isLaunched = true;
        rb.useGravity = true; // Activamos la gravedad cuando la bola es lanzada
        rb.AddForce(transform.forward * launchForce, ForceMode.Impulse); // Agregamos fuerza para el lanzamiento
    }
}
