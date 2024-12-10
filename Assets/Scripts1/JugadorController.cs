using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
    bool canMove;
    public int equipo;

    public delegate void OnHitObject(GameObject objeto);
    public event OnHitObject onHitObject;

    private void Start()
    {
        canMove = true;
        equipo = 0;
        // Ejemplo: Inicializar datos del jugador
        PlayerPrefs.SetString("level1", "Completado");
    }

    private void Update()
    {
        if (canMove)
        {
            // Movimiento del jugador
            if (Input.GetKey(KeyCode.Q)) transform.Rotate(0, -2f, 0); // Girar izquierda
            if (Input.GetKey(KeyCode.E)) transform.Rotate(0, 2f, 0);  // Girar derecha
            if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * 5f * Time.deltaTime; // Adelante
            if (Input.GetKey(KeyCode.S)) transform.position -= transform.forward * 5f * Time.deltaTime; // Atrás
            if (Input.GetKey(KeyCode.A)) transform.position -= transform.right * 5f * Time.deltaTime;   // Izquierda
            if (Input.GetKey(KeyCode.D)) transform.position += transform.right * 5f * Time.deltaTime;   // Derecha
        }
    }

    public void ObjectHit()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 12f))
        {
            Debug.DrawRay(transform.position, transform.forward * 12f, Color.red);
            onHitObject?.Invoke(hit.collider.gameObject);
        }
    }

    public void DisableMovement(float duration)
    {
        StartCoroutine(DisableMovementCoroutine(duration));
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    private IEnumerator DisableMovementCoroutine(float duration)
    {
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
    }
}