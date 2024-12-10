using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Dinamica : MonoBehaviour
{
    [SerializeField] Transform origen;
    //[SerializeField] TextMeshProUGUI txt_contador;
    public int contador;
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            transform.position = origen.transform.position;
            //Destroy(obj);
            //contador++;
            //  txt_contador.text = contador.ToString();
        }
        else if (obj.CompareTag("Ground"))
        {
            Debug.Log("PERDISTES PERRITA CHICHONA");
            contador++;

        }
    }

        public int getContador()
    {
        return contador;
    }
        
        // Start is called before the first frame update
        void Start()
        {
            contador = 0;
        }

        // Update is called once per frame
        void Update()
        {
           
        }
    
}
