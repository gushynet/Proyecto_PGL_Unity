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

        // Obtener la posición local y la rotación de la puerta
        puerta.transform.GetLocalPositionAndRotation(out pos, out q);

        // Si la puerta está abriéndose
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
            // Si la puerta está cerrándose y alcanza la posición de inicio (y >= 0)
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

        // Establecer la nueva posición local y rotación de la puerta
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
