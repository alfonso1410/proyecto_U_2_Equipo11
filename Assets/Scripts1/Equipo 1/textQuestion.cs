using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textQuestion : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler Continuar;

    [SerializeField] trigger_Start start_game;
    [SerializeField] Panel_Preguntas panelPreguntas;
    [SerializeField] JugadorController jugadorController; // Referencia al JugadorController

    TextMeshPro txtQuestion;

    private void Awake()
    {
        txtQuestion = GetComponent<TextMeshPro>();
    }

    void Start()
    {
        txtQuestion.text = "Holas";
        start_game.OnStartGame += Welcome;
        panelPreguntas.OnResult += Result;
    }

    void Result(bool isCorrect)
    {
        string aux;
        if (isCorrect)
        {
            aux = "¡Correcto!";
        }
        else
        {
            aux = "¡Incorrecto!";
        }

        StartCoroutine(showResult(aux));
    }

    IEnumerator showResult(string r)
    {
        int aux = 1;
        for (int i = 0; i < 10; i++)
        {
            txtQuestion.text = "Respuesta " + "\n" + new string('.', ++aux % 3);
            yield return new WaitForSeconds(0.25f);
        }

        txtQuestion.text = r;
        yield return new WaitForSeconds(4.0f);

        Continuar?.Invoke();
    }

    void Welcome()
    {
        StartCoroutine(Message());

        // Ahora, en lugar de usar la instancia estática, usamos la referencia asignada en el Inspector
        if (jugadorController != null)
        {
            jugadorController.DisableMovement(3.0f);
        }
    }

    IEnumerator Message()
    {
        txtQuestion.text = "¡Bienvenido!";
        yield return new WaitForSeconds(1.0f);
        txtQuestion.text = "Responde las preguntas para avanzar.";
        yield return new WaitForSeconds(2.0f);
        txtQuestion.text = "";
        Continuar?.Invoke();
    }

    private void OnDisable()
    {
        start_game.OnStartGame -= Welcome;
    }
}
