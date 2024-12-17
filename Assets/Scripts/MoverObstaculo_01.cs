using System;
using UnityEngine;

public class MoverObstaculo_01 : MonoBehaviour
{
    public GameObject obstaculo;
    public GameObject esfera;  // Referencia a la esfera que controlas con el teclado

    private float rotacionMinima, rotacionMaxima;
    private bool abriendose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicializamos las rotaciones mínimas y máximas de la puerta (obstáculo)
        rotacionMinima = 0f;   // La puerta está cerrada (sin rotación)
        rotacionMaxima = 90f;  // La puerta se abre hasta 90 grados

        abriendose = true;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotacion = obstaculo.transform.rotation;

        // Siempre rota en el mismo sentido
        if (abriendose)
        {
            // Si la puerta ha girado lo suficiente (hasta rotacionMaxima en Y), detener la apertura
            if (rotacion.eulerAngles.y >= rotacionMaxima)
            {
                abriendose = false;
                rotacion.eulerAngles = new Vector3(rotacion.eulerAngles.x, rotacionMaxima, rotacion.eulerAngles.z);  // Suaviza el cierre de la puerta
            }
            else
            {
                // Rota siempre en el sentido horario (aumenta el ángulo)
                rotacion.eulerAngles = new Vector3(rotacion.eulerAngles.x, rotacion.eulerAngles.y + 1f, rotacion.eulerAngles.z);  // Gira la puerta en sentido horario
            }
        }
        else
        {
            // Si la puerta está cerrándose y alcanza la rotación mínima (sin rotación)
            if (rotacion.eulerAngles.y <= rotacionMinima)
            {
                abriendose = true;  // Cambia a modo de apertura
                rotacion.eulerAngles = new Vector3(rotacion.eulerAngles.x, rotacionMinima, rotacion.eulerAngles.z);  // Suaviza la apertura de la puerta
            }
            else
            {
                // Si la puerta se está cerrando, la rotamos en el mismo sentido, pero hacia atrás
                rotacion.eulerAngles = new Vector3(rotacion.eulerAngles.x, rotacion.eulerAngles.y - 1f, rotacion.eulerAngles.z);  // Rota la puerta en sentido horario
            }
        }

        // Establecer la nueva rotación de la puerta (obstáculo)
        obstaculo.transform.rotation = rotacion;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si la colisión es con la esfera
        if (collision.gameObject.CompareTag("Jugador"))  // Asegúrate de que la esfera tenga el tag "Esfera"
        {
            Rigidbody esferaRb = collision.gameObject.GetComponent<Rigidbody>();  // Obtener el Rigidbody de la esfera
            if (esferaRb != null)
            {
                // Calcular la dirección en la que la esfera debe ser impulsada (alejándose de la puerta)
                Vector3 direccionDeImpulso = (collision.transform.position - obstaculo.transform.position).normalized;

                // Aplicar una fuerza hacia atrás para alejarla de la puerta
                esferaRb.AddForce(direccionDeImpulso * 5f, ForceMode.Impulse);  // La fuerza puede ajustarse
            }
        }
    }
}



