using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    E2_ManagerUI managerUI;
    // Start is called before the first frame update
    void Start()
    {
        managerUI = GameObject.Find("HandlerUI").GetComponent<E2_ManagerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin");
            managerUI.CollectCoin();
            other.gameObject.SetActive(false);
        }
    }
}
