using System;
using UnityEngine;

public class MoverPuerta_02 : MonoBehaviour
{
    public GameObject puerta;
    public GameObject esfera;  // Referencia a la esfera que controlas con el teclado

    private float min, max;
    private Boolean abriendose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Asumiendo que la puerta comienza en y = -10.48575 y queremos moverla hasta y = -8
        min = -10.48575f;  // La posici�n m�nima (cuando la puerta est� completamente cerrada)
        max = -8f;         // La posici�n m�xima (cuando la puerta se abre, unos 2.5 metros hacia arriba)
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
            // Si la puerta ha subido lo suficiente (hasta max en el eje Y), detener la apertura
            if (pos.y >= max)
            {
                abriendose = false;
                pos.y = Mathf.Lerp(pos.y, max, 0.9f);  // Suaviza el cierre de la puerta
            }
            else
            {
                pos.y = Mathf.Lerp(pos.y, pos.y + 0.05f, 0.1f);  // Mueve la puerta hacia arriba
            }
        }
        else
        {
            // Si la puerta est� cerr�ndose y alcanza la posici�n de inicio (min en Y)
            if (pos.y <= min)
            {
                abriendose = true;  // Cambia a modo de apertura
                pos.y = Mathf.Lerp(pos.y, min, 0.5f);  // Suaviza la apertura de la puerta
            }
            else
            {
                pos.y = Mathf.Lerp(pos.y, pos.y - 0.05f, 0.2f);  // Mueve la puerta hacia abajo
            }
        }

        // Establecer la nueva posici�n local y rotaci�n de la puerta
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



