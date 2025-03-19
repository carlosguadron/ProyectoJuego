using UnityEngine;

public class Pin : MonoBehaviour
{
    public int points = 10; // Puntos que dará este pin al tocar la bola
    public GameObject destroyEffect; // Efecto de partículas al destruir el pin

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Verifica si la bola toca el pin
        {
            GameManager.Instance.AddScore(points); // Suma puntos al marcador

            if (destroyEffect != null) // Si hay un efecto asignado, lo instanciamos
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // Elimina el pin
        }
    }
}
