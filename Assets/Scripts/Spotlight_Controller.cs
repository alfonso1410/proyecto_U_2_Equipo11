using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight_Controller : MonoBehaviour
{
    [SerializeField] private int juegoIndex; // Índice del juego asociado al Spotlight

    private void Start()
    {
        // Verifica si el juego ya está completado
        if (GameManager.Instance != null && GameManager.Instance.IsJuegoCompletado(juegoIndex - 1))
        {
            gameObject.SetActive(false); // Desactiva el Spotlight si el juego ya está completado
            Debug.Log($"Spotlight del juego {juegoIndex} desactivado porque el juego está completado.");
        }
    }
}