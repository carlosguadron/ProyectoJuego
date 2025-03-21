using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushForce = 5f; // Fuerza del empuje
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody del objeto
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // Si presionamos "SPACE"
        {
            rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse); // Aplica fuerza hacia adelante
        }
    }
}
