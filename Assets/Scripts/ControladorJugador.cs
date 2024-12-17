using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 0; //Al ser pública se verá en el inspector para el objeto Player
    //public float fuerzaSalto = 10f;  // Fuerza del salto
    public LayerMask sueloLayer;  // Capa para detectar el suelo
    public TextMeshProUGUI countText;

    private Rigidbody ComponenteRigidBody;
    private float MovimientoX, MovimientoY;
    private bool estaEnElSuelo;

    public string nombreEscena;
    private int PuntosConseguidos=1;

    public GameObject textoFlotantePrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ComponenteRigidBody = GetComponent<Rigidbody>();
        //PuntosConseguidos = 0;
        //countText.text = "Puntuación: " + PuntosConseguidos.ToString();

        if (ManagerPuntos.instance != null)
        {
            
            countText.text = "Puntuación: " + ManagerPuntos.instance.puntuacion.ToString();
        }
       
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        MovimientoX = movementVector.x;
        MovimientoY = movementVector.y;
    }

    // Método de salto, que será llamado cuando el jugador presione la barra espaciadora
    /*private void OnJump(InputValue jumpValue)
    {
        if (estaEnElSuelo) // Solo saltar si la esfera está en el suelo
        {
            Salto();
        }
    }*/

    // Método para hacer que la esfera salte
    /*void Salto()
    {
        // Aplicar un impulso hacia arriba
        ComponenteRigidBody.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        estaEnElSuelo = false;  // La esfera ya no está en el suelo
    }*/

    // Detectar cuando la esfera colisiona con el suelo para permitir saltar de nuevo
    private void OnCollisionEnter(Collision col)
    {
        // Verificamos si la esfera ha tocado un objeto con el tag "Suelo"
        if (col.gameObject.CompareTag("Suelo"))
        {
            estaEnElSuelo = true;  // La esfera puede saltar nuevamente
        }

        // Verifica si la colisión es con el Quad
        if (col.gameObject.CompareTag("Salida")) // Asegúrate de que el Quad tiene este tag
        {
            // Cambiar a la escena especificada
            Scene EscenaActiva = SceneManager.GetActiveScene();

            ManagerPuntos.instance.TiempoNivel01 = ManagerPuntos.instance.tiempoTranscurrido;
            SceneManager.LoadScene(nombreEscena);
        }

        if (col.gameObject.CompareTag("Salida2")) // Asegúrate de que el Quad tiene este tag
        {
            // Cambiar a la escena especificada
            ManagerPuntos.instance.TiempoNivel02 = ManagerPuntos.instance.tiempoTranscurrido;
            SceneManager.LoadScene(nombreEscena);
        }
    }




    private void FixedUpdate()
    {
        Vector3 movimiento = new Vector3(MovimientoX, 0.0f, MovimientoY);

        ComponenteRigidBody.AddForce(movimiento * velocidad);

        // Verificar si la esfera está tocando el suelo para poder saltar
        VerificarSiEnElSuelo();
    }

    void VerificarSiEnElSuelo()
    {
        // Verificar si la esfera está tocando el suelo
        if (Physics.Raycast(transform.position, Vector3.down, 0.1f, sueloLayer))
        {
            estaEnElSuelo = true;
        }
        else
        {
            estaEnElSuelo = false;
        }
    }


    //Este método se ejecuta automáticamente cuando otro objeto (que tiene un Collider) entra en el área de colisión de un objeto que tiene un Collider con la casilla is Trigger activada.
    //Parámetro Collider other: Este parámetro hace referencia al Collider del otro objeto que entra en la zona del Trigger.
    //El other es el objeto que ha tocado el trigger del objeto que tiene este script.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PuntoAzul") == true) //Esto es lo que se ha añadido. Si hemos colisionado con un cubo, lo hacemos desaparecer.

        {
            //other.gameObject: Accede al GameObject (objeto del juego) al que pertenece el Collider que acaba de entrar en la zona del trigger.
            //SetActive(false): Desactiva ese GameObject. Esto hace que el objeto desaparezca en la escena (no se renderiza ni interactúa más en el juego),
            //pero el objeto sigue existiendo en la jerarquía de la escena.
            other.gameObject.SetActive(false);
            ManagerPuntos.instance.IncrementarPuntuacion(1);
            countText.text = "Puntuación: " + ManagerPuntos.instance.puntuacion.ToString();
            

            //other.gameObject.SetActive(false);
            //PuntosConseguidos = PuntosConseguidos + 1;
            //countText.text = "Puntuación: " + PuntosConseguidos.ToString();

            // Instancia el texto flotante en la posición del cubo
            Vector3 cuboPosition = other.transform.position;

            // Instancia el prefab del texto flotante en la posición del cubo
            GameObject textoFlotante = Instantiate(textoFlotantePrefab, cuboPosition, Quaternion.identity);

            // Asegúrate de que el texto flotante esté dentro del Canvas
            Canvas canvas = FindObjectOfType<Canvas>();

            if (canvas != null)
            {
                textoFlotante.transform.SetParent(canvas.transform, false);  // Establece el Canvas como el padre del texto flotante
            }
            else
            {
                Debug.LogError("No se encontró un Canvas en la escena");
            }

            // Ajusta la posición del texto flotante para que esté un poco por encima del cubo
            //textoFlotante.GetComponent<RectTransform>().position = cuboPosition + new Vector3(0, 1, 0); // Ajusta la altura

            RectTransform rectTransform = textoFlotante.GetComponent<RectTransform>();
            rectTransform.position = cuboPosition + new Vector3(0, 1, 0); // Ajusta la altura para que se vea un poco por encima del cubo
            


            StartCoroutine(FadeOutText(textoFlotante, 2f));
        }

        // Corrutina para hacer que el texto desaparezca
        IEnumerator FadeOutText(GameObject textoFlotante, float duration)
        {
            // Espera durante el tiempo especificado
            yield return new WaitForSeconds(duration);

            // Destruye el objeto del texto flotante después de la espera
            Destroy(textoFlotante);
        }


    }

    

    

}
