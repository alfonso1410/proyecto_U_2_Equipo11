using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RutinaTiempo : MonoBehaviour
{
    [SerializeField] private int juegoIndex; // Índice del juego asociado
    [SerializeField] private TextMeshProUGUI Texto_Tiempo; // Referencia al texto del temporizador

    private int contadorSegundos;
    private GameObject enemigo;

    private void Awake()
    {
        enemigo = GameObject.Find("Enemigo");
    }

    // Start is called before the first frame update
    void Start()
    {
        contadorSegundos = 5; // Duración del juego
        StartCoroutine(CorrutinaTiempo());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Escena de derrota si el enemigo atrapa al jugador
            SceneManager.LoadScene(0); // Escena de muerte
            Debug.Log("¡El enemigo te atrapó! Has perdido.");
        }
    }

    private IEnumerator CorrutinaTiempo()
    {
        // Temporizador que reduce cada segundo
        while (contadorSegundos >= 0)
        {
            Texto_Tiempo.text = contadorSegundos.ToString();
            contadorSegundos--;
            yield return new WaitForSeconds(1f);
        }

        // Marca el juego como completado al finalizar el tiempo
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CompletarJuego(juegoIndex - 1);
            Debug.Log($"¡Ganaste el juego {juegoIndex}! Regresando a la escena principal.");
        }

        // Regresa a la escena principal
        SceneManager.LoadScene(0);
    }
}
