using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_Start : MonoBehaviour
{
    public delegate void StartGame();
    public event StartGame OnStartGame;

    [SerializeField] Panel_Preguntas panelPreguntas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnStartGame();
            gameObject.SetActive(false);
        }
    }
}
