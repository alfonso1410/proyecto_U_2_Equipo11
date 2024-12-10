using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E2_ManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtTimer;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject panelResult;
    [SerializeField] private JugadorController jugadorController; // Asignar desde el Inspector

    private TextMeshProUGUI[] txts;
    private int segundos;
    private int coins;

    private void Start()
    {
        if (jugadorController == null)
        {
            // Encuentra automáticamente el jugador si no se asignó en el Inspector
            jugadorController = FindObjectOfType<JugadorController>();
        }

        if (jugadorController != null)
        {
            jugadorController.transform.position = spawn.transform.position;
            jugadorController.transform.rotation = spawn.transform.rotation;

            jugadorController.gameObject.AddComponent<CoinCollector>();
        }

        segundos = 60;
        coins = 0;
        txtScore.text = "0 / 7";
        StartCoroutine(Timer());
        txts = panelResult.GetComponentsInChildren<TextMeshProUGUI>();
    }

    public void CollectCoin()
    {
        coins += 1;
        txtScore.text = coins + " / 7";
    }

    private IEnumerator Timer()
    {
        while (segundos >= 0 && coins < 7)
        {
            txtTimer.text = FormatTimer(segundos);
            segundos--;
            yield return new WaitForSeconds(1.0f);
        }

        Score();
    }

    private string FormatTimer(int seconds)
    {
        int min = seconds / 60;
        int sec = seconds % 60;
        return $"{min:00}:{sec:00}";
    }

    private void Score()
    {
        int score = coins;
        panelResult.SetActive(true);
        txts[0].text = "Level 2";
        txts[1].text = $"Score: \n{score}/7";
        PlayerPrefs.SetString("level2", "Completo");

        // Comprueba si el jugador tiene 7 monedas y marca el juego como completado
        if (coins == 7 && GameManager.Instance != null)
        {
            GameManager.Instance.CompletarJuego(1); // Asumiendo que el índice del juego es 1
            Debug.Log($"¡Ganaste el juego 2! Regresando a la escena principal.");
        }

        if (jugadorController != null)
        {
            jugadorController.DisableMovement(2.5f);
        }

        Invoke(nameof(GoBack), 3.0f);
    }


    private void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        if (jugadorController != null)
        {
            var coinCollector = jugadorController.GetComponent<CoinCollector>();
            if (coinCollector != null)
            {
                Destroy(coinCollector);
            }
        }
    }
}
