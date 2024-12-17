using System;
using UnityEngine;

public class MoverPuerta_05 : MonoBehaviour
{
    public GameObject puerta;
    public GameObject esfera;  // Referencia a la esfera que controlas con el teclado

    private float rotacionMinima, rotacionMaxima;
    private Boolean abriendose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicializamos las rotaciones mínimas y máximas de la puerta.
        rotacionMinima = 0f;   // La puerta está cerrada (sin rotación)
        rotacionMaxima = 90f;  // La puerta se abre hasta 90 grados

        abriendose = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        Quaternion q;

        // Obtener la posición local y la rotación de la puerta
        puerta.transform.GetLocalPositionAndRotation(out pos, out q);

        // Si la puerta está abriéndose
        if (abriendose)
        {
            // Si la puerta ha girado lo suficiente (hasta rotacionMaxima en Y), detener la apertura
            if (q.eulerAngles.y >= rotacionMaxima)
            {
                abriendose = false;
                q.eulerAngles = new Vector3(q.eulerAngles.x, rotacionMaxima, q.eulerAngles.z);  // Suaviza el cierre de la puerta
            }
            else
            {
                q.eulerAngles = new Vector3(q.eulerAngles.x, Mathf.Lerp(q.eulerAngles.y, q.eulerAngles.y + 1f, 0.1f), q.eulerAngles.z);  // Gira la puerta
            }
        }
        else
        {
            // Si la puerta está cerrándose y alcanza la rotación mínima (sin rotación)
            if (q.eulerAngles.y <= rotacionMinima)
            {
                abriendose = true;  // Cambia a modo de apertura
                q.eulerAngles = new Vector3(q.eulerAngles.x, rotacionMinima, q.eulerAngles.z);  // Suaviza la apertura de la puerta
            }
            else
            {
                q.eulerAngles = new Vector3(q.eulerAngles.x, Mathf.Lerp(q.eulerAngles.y, q.eulerAngles.y - 1f, 0.2f), q.eulerAngles.z);  // Gira la puerta
            }
        }

        // Establecer la nueva rotación de la puerta
        puerta.transform.SetLocalPositionAndRotation(pos, q);
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
                Vector3 direccionDeImpulso = (collision.transform.position - puerta.transform.position).normalized;

                // Aplicar una fuerza hacia atrás para alejarla de la puerta
                esferaRb.AddForce(direccionDeImpulso * 5f, ForceMode.Impulse);  // La fuerza puede ajustarse
            }
        }
    }
}

