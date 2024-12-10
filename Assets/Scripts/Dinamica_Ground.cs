using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinamica_Ground : MonoBehaviour
{
    [SerializeField] Transform origen;
    //[SerializeField] TextMeshProUGUI txt_contador;
    //int contador;
    private void OnCollisionEnter(Collision other){
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Enemy")){
            Destroy(obj);
            
        }
        
    }
    // Start is called before the first frame update
  
}
