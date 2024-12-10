using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientocompuesto : MonoBehaviour
{
    float velocidad_rotacion = 10f;
    float velocidad_movimiento = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angulo = 10f * velocidad_rotacion * Time.deltaTime;
        //rotar izquierda y derecha
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, angulo * -1, 0);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, angulo, 0);
        }

        //mover arriba y abajo 
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * velocidad_movimiento * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -1 * velocidad_movimiento * Time.deltaTime;
        }

        //mover izquierda y derecha
        if (Input.GetKey(KeyCode.A))
        { 
            transform.position += transform.right * -1 * velocidad_movimiento * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * velocidad_movimiento * Time.deltaTime;
        }


    }
}