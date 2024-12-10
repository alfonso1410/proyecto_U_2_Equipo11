using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler : MonoBehaviour
{
    // Start is called before the first frame update

    Dinamica dinam;
    void GoBack()
    {
     //   if (dinam.contador == 3)
       // {
         //   SceneManager.LoadScene(0);
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(GoBack), 3f);
    }
}
