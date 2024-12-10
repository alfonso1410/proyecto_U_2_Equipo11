using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRotacion : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 25f;
    [SerializeField] E2_ManagerUI managerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angulo = 5f * rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) //Adelante
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W)) //Atras
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime * -1;
        }

        if(Input.GetKey(KeyCode.D)) //Izquierda
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime * -1;
        }
        else if (Input.GetKey(KeyCode.A)) //Derecha
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q)) //Izquierda
        {
            transform.Rotate(0, angulo * -1, 0);
        }
        else if (Input.GetKey(KeyCode.E)) //Derecha
        {
            transform.Rotate(0, angulo, 0);
        }
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Coin")
    //    {
    //        Debug.Log("Coin");
    //        managerUI.CollectCoin();
    //        collision.gameObject.SetActive(false);
    //    }
    //}
}
