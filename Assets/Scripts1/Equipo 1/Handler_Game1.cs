using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler_Game1 : MonoBehaviour
{
    [SerializeField] private JugadorController jugadorController; // Referencia a JugadorController en el Inspector
    [SerializeField] private int juegoIndex; // Índice del juego, asignable desde el Inspector
    [SerializeField] Transform spawn;
    [SerializeField] Panel_Preguntas panelPreguntas;
    [SerializeField] GameObject panelResult;

    TextMeshProUGUI[] txts;
    int score;

    private void Awake()
    {
        txts = panelResult.GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        score = 0;
        txts[0].text = "Level 5"; // Borrar luego

        // Asignamos la posición y rotación del jugador
        if (jugadorController != null)
        {
            jugadorController.gameObject.transform.position = spawn.position;
            jugadorController.gameObject.transform.rotation = spawn.rotation;
        }

        panelPreguntas.OnEndGame += Score;
    }

    void Score()
    {
        score = panelPreguntas.getCorrectAnswers(); // Obtiene las respuestas correctas
        panelResult.SetActive(true);
        txts[1].text = "Score: " + "\n" + score + "/5";

        // Si el jugador obtiene al menos 3 respuestas correctas
        bool gameWon = score >= 3; // Define si el juego fue ganado o no
        if (gameWon)
        {
            PlayerPrefs.SetString("level5", "Completo"); // Marca el juego como completado
          //  Debug.Log($"¡Felicidades! Has ganado el juego {juegoIndex}."); // Mensaje de victoria
            GameManager.Instance.CompletarJuego(juegoIndex - 1); // Marca el juego como completado en GameManager

            // Mostrar mensaje de victoria
            GameManager.Instance.ShowMessage("¡Ganaste el Juego!", 3f);
            Invoke("GoBack", 3f);
        }
        else
        {
          //  Debug.Log($"No has ganado el juego {juegoIndex}. Necesitas al menos 3 respuestas correctas.");

            // Mostrar mensaje de derrota
            GameManager.Instance.ShowMessage("Juego Perdido. Intenta de nuevo.", 3f);
            Invoke("GoBack", 3f);
        }

        jugadorController.DisableMovement(2.5f);
    }

    void GoBack()
    {
        SceneManager.LoadScene(0); // Regresa a la escena principal
    }

    private void OnDisable()
    {
        panelPreguntas.OnEndGame -= Score;
    }
}
