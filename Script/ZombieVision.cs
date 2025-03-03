using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVision : MonoBehaviour
{
    public Transform player; //Referencia del jugador
    public float CampoDeVision = 120f; //Campo de vision del zombie en grados

    void Update()
    {
        //Vector de direccion del zombi hacia adelante
        Vector3 zombieForward = transform.forward.normalized;

        // Vector desde el zombi hasta el jugador
        Vector3 toPlayer = (player.position - transform.position).normalized;

        float dotProduct = Vector3.Dot(zombieForward, toPlayer);
        float angleToOlayer = Mathf.Acos(dotProduct) * Mathf.Rad2Deg; //Convertimos a grados

        if (angleToOlayer < CampoDeVision / 2)
        {
            Debug.Log("¡El zombi puede ve al jugador!");
        }
        else
        {
            Debug.Log("El zombi NO puede ver al jugador.");
        }
    }
}
