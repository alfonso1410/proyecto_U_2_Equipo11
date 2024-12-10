using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Juego_1 : MonoBehaviour
{
    [SerializeField] private int juegoIndex; // Índice del juego asociado al portal
    private void Start()
    {


        // Verifica si el juego ya está completado
        if (GameManager.Instance != null && GameManager.Instance.IsJuegoCompletado(juegoIndex - 1))
        {
            gameObject.SetActive(false); // Desactiva el portal si el juego ya está completado
            Debug.Log($"Portal del juego {juegoIndex} desactivado porque ya está completado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en colisión es el jugador
        if (other.CompareTag("Player"))
        {




            if (GameManager.Instance != null && GameManager.Instance.IsJuegoCompletado(juegoIndex - 1))
            {
                Debug.Log($"El juego {juegoIndex} ya está completado. No puedes volver a entrar.");
                return; // Evita que el jugador entre a la escena si ya está completada
            }
            GameManager.Instance.setpos(new Vector3((transform.position.x + 5f), (transform.position.y + 4f), transform.position.z));

            GameManager.Instance.ShowMessage("¡Bienvenido al Juego " + juegoIndex + "!", 2f);
            // Cambia a la escena 1
            Invoke("Goback", 5f);
            Debug.Log($"Portal activado. Entrando al juego {juegoIndex}.");
        }
    } 

    void Goback()
    {
        SceneManager.LoadScene(1);
    }
}
