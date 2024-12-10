using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public static PlayerPositionManager Instance { get; private set; }

    private Vector3 playerPositionInScene0;  // Guardamos la posici�n solo de la escena 0
    private bool isPositionSaved = false;  // Para saber si la posici�n ha sido guardada

    private void Awake()
    {
        // Aseguramos que solo haya una instancia de este objeto
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Este objeto persiste entre escenas
        }
    }

    // Guardamos la posici�n cuando el jugador sale de la escena 0
    public void SavePlayerPosition(Vector3 position)
    {
        playerPositionInScene0 = position;
        isPositionSaved = true;  // Marcamos que la posici�n est� guardada
    }

    // Restauramos la posici�n cuando el jugador regresa a la escena 0
    public Vector3 GetSavedPosition()
    {
        if (isPositionSaved)
        {
            return playerPositionInScene0;
        }
        return Vector3.zero;  // Si no se ha guardado ninguna posici�n, devolver Vector3.zero
    }
}
