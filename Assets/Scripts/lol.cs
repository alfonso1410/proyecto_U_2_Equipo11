using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lol : MonoBehaviour
{
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float jumpForce = 5.0f; // Ajusta el valor si es necesario

    private Rigidbody fisicas;
    private bool isGrounded; // Variable para saber si est� en el suelo

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fisicas = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        // Rotaci�n
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * rotationSpeed, 0));

        // Salto solo si est� en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            fisicas.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false; // Al saltar, ya no est� en el suelo
        }
    }

    // Detecta cuando el personaje toca el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player toc� el suelo.");
            isGrounded = true; // Est� en el suelo
        }
    }

    // Detecta cuando el personaje deja de tocar el suelo
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player sali� del suelo.");
            isGrounded = false; // Ya no est� en el suelo
        }
    }
}

