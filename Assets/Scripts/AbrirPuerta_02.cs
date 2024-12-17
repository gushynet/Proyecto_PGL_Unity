using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AbrirPuerta_02 : MonoBehaviour
{
    public GameObject puerta;  // La puerta que se abrirá
    public GameObject esfera;  // La esfera controlada por el jugador

    private float min, max;
    private bool puertaAbierta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // La puerta comienza en la posición cerrada y debe abrirse hasta la posición máxima
        min = -10.48575f;  // Posición cuando la puerta está cerrada
        max = -8f;         // Posición máxima de apertura de la puerta
        puertaAbierta = false;  // La puerta comienza cerrada
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        Quaternion q;

        // Obtener la posición local y la rotación de la puerta
        puerta.transform.GetLocalPositionAndRotation(out pos, out q);

        // Si la puerta ya ha sido abierta, no hacemos nada más
        if (puertaAbierta == false)
        {
            return;
        }
        else
        {
            //pos.y = Mathf.Lerp(pos.y, pos.y + 0.05f, 0.1f);
            pos.y = Mathf.Lerp(pos.y, min, 0.5f);

        }

        puerta.transform.SetLocalPositionAndRotation(pos, q);

        // Obtener la posición de la puerta
        //Vector3 pos = puerta.transform.localPosition;

        // Si la puerta no ha llegado a la posición de apertura máxima, la abrimos
        /*if (pos.y < max)
        {
            pos.y = Mathf.Lerp(pos.y, max, 0.1f);  // Suaviza el movimiento de apertura
            puerta.transform.localPosition = pos;
        }
        else
        {
            // Cuando llegue a la posición máxima, marcarla como abierta
            puertaAbierta = true;
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
      
        // Si la colisión es con la esfera
        if (esfera.gameObject.CompareTag("Jugador"))  // Asegúrate de que la esfera tenga el tag "Jugador"
        {
            // Solo abrir la puerta si no se ha abierto ya
            if (puertaAbierta == false)
            {
                // Se activa el movimiento para abrir la puerta
                puertaAbierta = true;  // Esta variable garantiza que solo la abremos una vez
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 pos;
        Quaternion q;



        if (other.gameObject.CompareTag("Jugador") == true) //Esto es lo que se ha añadido. Si hemos colisionado con un cubo, lo hacemos desaparecer.

        {
            puerta.gameObject.SetActive(false);

            // Obtener la posición local y la rotación de la puerta
           // puerta.transform.GetLocalPositionAndRotation(out pos, out q);
            this.gameObject.SetActive(false);

            //pos.y = Mathf.Lerp(pos.y, min, 0.5f);
            //puerta.transform.SetLocalPositionAndRotation(pos, q);
           
            /*if (puertaAbierta == false)
            {
                // Se activa el movimiento para abrir la puerta
                puertaAbierta = true;  // Esta variable garantiza que solo la abremos una vez
                pos.y = Mathf.Lerp(pos.y, min, 0.5f);
                puerta.transform.SetLocalPositionAndRotation(pos, q);
            }*/

            //puerta.transform.SetPositionAndRotation(pos,q);
        }


    }
}

