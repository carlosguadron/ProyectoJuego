using UnityEngine;

public class playercontroller : MonoBehaviour
{
    
    public float rotationSpeed = 300f;
    public float movementSpeed = 100f;
    public float maxVelocity = 200f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            rb.AddForce(-transform.forward * movementSpeed);
        }
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
       
    }
}
