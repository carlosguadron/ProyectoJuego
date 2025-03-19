using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Verifica si la bola entró en la zona de eliminación
        {
            Destroy(other.gameObject); // Elimina la bola
            GameManager.Instance.EndTurn(); // Llama al sistema de turnos
        }
    }
}
