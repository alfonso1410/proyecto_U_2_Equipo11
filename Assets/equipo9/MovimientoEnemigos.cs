using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculoDistancia : MonoBehaviour
{
    public Transform ubi_player; // El transform del jugador
    float velociad = 5f; // Velocidad de movimiento de los enemigos
    private Vector3 ultimaPosPlayer; // Última posición del jugador

    void Start()
    {
        // Inicializa la última posición del jugador
        ultimaPosPlayer = ubi_player.position;
    }

    void Update()
    {
        if (ubi_player.position != ultimaPosPlayer)
        {
            Debug.Log("El jugador se está moviendo.");
            MoveTowardsPlayer();
        }
        else
        {
            Debug.Log("El jugador está quieto.");
        }
        ultimaPosPlayer = ubi_player.position;
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (ubi_player.position - transform.position).normalized;
        transform.position += direction * velociad * Time.deltaTime;
    }
}
