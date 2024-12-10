using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_escena : MonoBehaviour
{
    public static Cambio_escena Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int index_escena = SceneManager.GetActiveScene().buildIndex;

            // Cambia entre la escena 0 y 1
            if (index_escena == 0)
            {
                cambioEscena(1);
            }
            else if (index_escena == 1)
            {
                cambioEscena(0);
            }
        }
    }

    public void cambioEscena(int idx)
    {

        SceneManager.LoadScene(idx);
    }


}