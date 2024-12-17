using UnityEngine;
using System.Collections;

public class PlatformElevator : MonoBehaviour
{
    public float targetHeight = 4.3f;  // Altura a la que se elevará la plataforma
    public float liftSpeed = 2f;       // Velocidad de elevación de la plataforma
    public float waitTime = 2f;        // Tiempo de espera antes de elevar la plataforma
    private Vector3 originalPosition;  // Posición original de la plataforma
    private bool waiting = false;      // Indicador para saber si la plataforma está esperando
    private bool playerOnPlatform = false;  // Indicador de si el jugador está sobre la plataforma
    private Transform player;          // Referencia al transform de la esfera (jugador)
    private Rigidbody playerRb;        // Referencia al Rigidbody de la esfera
    private Collider platformCollider; // Collider de la plataforma

    void Start()
    {
        originalPosition = transform.position;  // Guardamos la posición original de la plataforma
        platformCollider = GetComponent<Collider>();  // Obtenemos el collider de la plataforma
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))  // Asegúrate de que la esfera tenga el tag "Jugador"
        {
            playerOnPlatform = true;  // Indicamos que el jugador está sobre la plataforma
            player = other.transform; // Guardamos la referencia al transform de la esfera
            playerRb = player.GetComponent<Rigidbody>(); // Referencia al Rigidbody de la esfera

            // Desactivar la gravedad del jugador mientras está en la plataforma
            if (playerRb != null)
            {
                playerRb.useGravity = false;
            }

            if (!waiting)
            {
                StartCoroutine(WaitBeforeElevating());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))  // Asegúrate de que la esfera tenga el tag "Jugador"
        {
            playerOnPlatform = false;   // Indicamos que el jugador ya no está sobre la plataforma
            player = null;              // Limpiamos la referencia al transform de la esfera

            if (playerRb != null)
            {
                playerRb.useGravity = true; // Reactivamos la gravedad para que la esfera vuelva a caer
            }

            playerRb = null;            // Limpiamos la referencia al Rigidbody de la esfera
        }
    }

    private IEnumerator WaitBeforeElevating()
    {
        waiting = true;  // Indicamos que estamos en espera
        yield return new WaitForSeconds(waitTime); // Esperar antes de subir

        if (playerOnPlatform && player != null)
        {
            StartCoroutine(ElevatePlatform());
        }
        waiting = false;  // Terminamos el tiempo de espera
    }

    private IEnumerator ElevatePlatform()
    {
        Vector3 targetPosition = new Vector3(originalPosition.x, originalPosition.y + targetHeight, originalPosition.z);

        while (transform.position.y < targetPosition.y)
        {
            // Mover la plataforma hacia la posición objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, liftSpeed * Time.deltaTime);

            // Mover la esfera con la plataforma (solo si está sobre ella)
            if (playerOnPlatform && playerRb != null)
            {
                Vector3 newPlayerPosition = new Vector3(player.position.x, transform.position.y + 0.5f, player.position.z);
                playerRb.MovePosition(newPlayerPosition);
            }

            yield return null;  // Espera hasta el siguiente frame
        }

        StartCoroutine(LowerPlatform());
    }

    private IEnumerator LowerPlatform()
    {
        yield return new WaitForSeconds(waitTime);  // Esperar antes de bajar

        while (transform.position.y > originalPosition.y)
        {
            // Mover la plataforma hacia la posición original
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, liftSpeed * Time.deltaTime);

            // Mover la esfera con la plataforma (solo si está sobre ella)
            if (playerOnPlatform && playerRb != null)
            {
                Vector3 newPlayerPosition = new Vector3(player.position.x, transform.position.y + 0.5f, player.position.z);
                playerRb.MovePosition(newPlayerPosition);
            }

            yield return null;  // Espera hasta el siguiente frame
        }

        if (playerRb != null)
        {
            playerRb.useGravity = true; // Reactivamos la gravedad de la esfera
        }

        playerOnPlatform = false;  // Ya no hay jugador en la plataforma
        player = null;              // Limpiamos la referencia del jugador
        playerRb = null;            // Limpiamos la referencia al Rigidbody de la esfera
    }
}
