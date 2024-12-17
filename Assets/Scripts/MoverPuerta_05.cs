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
        // Inicializamos las rotaciones m�nimas y m�ximas de la puerta.
        rotacionMinima = 0f;   // La puerta est� cerrada (sin rotaci�n)
        rotacionMaxima = 90f;  // La puerta se abre hasta 90 grados

        abriendose = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        Quaternion q;

        // Obtener la posici�n local y la rotaci�n de la puerta
        puerta.transform.GetLocalPositionAndRotation(out pos, out q);

        // Si la puerta est� abri�ndose
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
            // Si la puerta est� cerr�ndose y alcanza la rotaci�n m�nima (sin rotaci�n)
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

        // Establecer la nueva rotaci�n de la puerta
        puerta.transform.SetLocalPositionAndRotation(pos, q);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si la colisi�n es con la esfera
        if (collision.gameObject.CompareTag("Jugador"))  // Aseg�rate de que la esfera tenga el tag "Esfera"
        {
            Rigidbody esferaRb = collision.gameObject.GetComponent<Rigidbody>();  // Obtener el Rigidbody de la esfera
            if (esferaRb != null)
            {
                // Calcular la direcci�n en la que la esfera debe ser impulsada (alej�ndose de la puerta)
                Vector3 direccionDeImpulso = (collision.transform.position - puerta.transform.position).normalized;

                // Aplicar una fuerza hacia atr�s para alejarla de la puerta
                esferaRb.AddForce(direccionDeImpulso * 5f, ForceMode.Impulse);  // La fuerza puede ajustarse
            }
        }
    }
}

