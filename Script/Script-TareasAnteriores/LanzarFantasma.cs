using UnityEngine;

public class LanzarFantasma : MonoBehaviour
{
    public float fuerzaLanzamiento = 5f; // Fuerza hacia arriba

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero; // Resetea velocidad previa
            rb.AddForce(Vector3.up * fuerzaLanzamiento, ForceMode.Impulse);
        }
    }
}