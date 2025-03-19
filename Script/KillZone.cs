using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Verifica si la bola entr� en la zona de eliminaci�n
        {
            Destroy(other.gameObject); // Elimina la bola
            GameManager.Instance.EndTurn(); // Llama al sistema de turnos
        }
    }
}
