using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool[] juegosCompletados = new bool[4]; // Array para guardar el estado de los juegos 1-4
    Vector3 posOld;
    public int a = 0;

    [SerializeField] private GameObject messagePanel;  // El panel que contiene el mensaje
    [SerializeField] private TextMeshProUGUI messageText;  // El componente TextMeshProUGUI dentro del panel

    public void setpos(Vector3 pos)
    {
        a = 1;
        posOld = pos;
    }

    public Vector3 getpos()
    {
        return posOld;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste el GameManager entre escenas
        }

     

        // Suscribirse al evento de carga de escenas
       SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false); // Desactiva el panel al inicio
        }
    }

    // Método para manejar la carga de escenas
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            messagePanel = canvas.transform.Find("PanelMessage")?.gameObject;
            messageText = messagePanel?.GetComponentInChildren<TextMeshProUGUI>();
        }
    }


    public void CompletarJuego(int index)
    {
        if (index >= 0 && index < juegosCompletados.Length)
        {
            juegosCompletados[index] = true; // Marca el juego como completado
        }
    }

    public bool IsJuegoCompletado(int index)
    {
        if (index >= 0 && index < juegosCompletados.Length)
        {
            return juegosCompletados[index];
        }
        return false;
    }

    public void ShowMessage(string message, float duration = 3f)
    {
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(true);  // Muestra el panel
            messageText.text = message;   // Asigna el texto

            // Inicia la corutina para ocultar el mensaje después de cierto tiempo
            StartCoroutine(HideMessageAfterDelay(duration));
        }
    }

    // Corutina para ocultar el mensaje después de un tiempo
    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Espera el tiempo especificado

        // Verifica si el messagePanel aún existe antes de intentar desactivarlo
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);  // Oculta el panel después de 3 segundos
        }
    }

    // Asegúrate de limpiar el evento cuando ya no lo necesites
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
   }
}
