using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraDeAburrimiento : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float tiempoMaximo = 100f;  // Valor inicial de la barra
    public float velocidadReduccion = 1f; // Velocidad con la que se reduce el aburrimiento

    private void Start()
    {
        slider.maxValue = tiempoMaximo;
        slider.value = tiempoMaximo;
    }

    private void Update()
    {
        // Reduce el valor de la barra
        slider.value -= velocidadReduccion * Time.deltaTime;

        // Si la barra se vacía, termina el juego
        if (slider.value <= 0)
        {
            TerminarJuego();
        }
    }

    private void TerminarJuego()
    {
        // Aquí puedes implementar lo que deseas que ocurra al terminar el juego
        Debug.Log("¡El juego ha terminado por aburrimiento!");
        // Por ejemplo, cargar la escena de Game Over o reiniciar el juego
        SceneManager.LoadScene(2); // Asegúrate de tener una escena "GameOver" configurada en el build
    }
}