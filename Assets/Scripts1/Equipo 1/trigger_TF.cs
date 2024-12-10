using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trigger_TF : MonoBehaviour
{
    [SerializeField] triggerController1 triggerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerController.OnTriggerEntered(other, gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerController.OnTriggerExited(other);
        }
    }
}
