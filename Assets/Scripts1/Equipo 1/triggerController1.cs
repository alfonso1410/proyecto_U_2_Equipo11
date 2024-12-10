using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController1 : MonoBehaviour
{
    int option;

    public int getOption()
    {
        return option;
    }

    public void OnTriggerEntered(Collider other, GameObject g)
    {
        if (g.name == "T_True")
        {
            option = 1;
            Debug.Log("Correcto");
        }
        else if (g.name == "T_False")
        {
            option = 0;
            Debug.Log("Incorrecto");
        }
    }

    public void OnTriggerExited(Collider other)
    {
        option = -1;
    }

    void Start()
    {
        option = -1;
    }
}
