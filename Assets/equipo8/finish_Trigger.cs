using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_Trigger : MonoBehaviour
{
    [SerializeField] private int juegoIndex; // Índice de la escena actual

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CompletarJuego(juegoIndex - 1);
            GameManager.Instance.ShowMessage("Juego " + juegoIndex + " Completado!! Regresando a la escena principal");
            // Debug.Log($"¡Juego {juegoIndex} completado! Actualizando estado del portal en la escena principal.");
            Invoke("Goback", 5f);
        }
    }

    void Goback()
    {
        SceneManager.LoadScene(0);
    }
}