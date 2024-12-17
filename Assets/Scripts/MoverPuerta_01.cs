using System;
using UnityEngine;

public class MoverPuerta_01 : MonoBehaviour
{
    public GameObject puerta;

    public GameObject esfera;  // Referencia a la esfera que controlas con el teclado

    private float min, max;
    private Boolean abriendose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        min = -2.6f;
        max = 0.9f;
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
            // Si la puerta ha bajado lo suficiente (hasta -2.0f en y), detener la apertura
            if (pos.z <= min)  // Puedes ajustar este valor para que la puerta baje lo suficiente para que pase la esfera
            {
                abriendose = false;
                pos.z = Mathf.Lerp(pos.z, min, 0.9f);  // Suaviza el cierre de la puerta
            }
            else
            {
                pos.z = Mathf.Lerp(pos.z, pos.z - 0.05f, 0.1f);  // Mueve la puerta hacia abajo
            }
        }
        else
        {
            // Si la puerta est� cerr�ndose y alcanza la posici�n de inicio (y >= 0)
            if (pos.z >= 0)
            {
                abriendose = true;  // Cambia a modo de apertura
                pos.z = Mathf.Lerp(pos.z, max, 0.5f);  // Suaviza la apertura de la puerta
            }
            else
            {
                pos.z = Mathf.Lerp(pos.z, pos.z + 0.05f, 0.2f);  // Mueve la puerta hacia arriba
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
