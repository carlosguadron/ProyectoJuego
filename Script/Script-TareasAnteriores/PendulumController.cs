using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public float pushForce = 100f; // Fuerza aumentada
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Asegurarnos que no hay fuerzas iniciales
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Empuje inicial en el eje correcto (usando torque)
        rb.AddTorque(Vector3.forward * pushForce, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Limpiamos velocidades previas
            rb.angularVelocity = Vector3.zero;
            // Aplicamos torque en el eje Z
            rb.AddTorque(Vector3.forward * pushForce, ForceMode.VelocityChange);
        }
    }
}