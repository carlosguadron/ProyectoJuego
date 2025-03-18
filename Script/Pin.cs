using UnityEngine;

public class Pin : MonoBehaviour
{
    public int points = 10; // Puntos que dará este pin al tocar la bola

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Verifica si la bola toca el pin
        {
            GameManager.Instance.AddScore(points); // Suma puntos al marcador
        }
    }
}
