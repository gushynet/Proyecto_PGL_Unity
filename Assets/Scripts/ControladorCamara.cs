using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 offset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - jugador.transform.position;
        
    }

    // Como con update no controlamos el orden en que se realizan los updates, por lo que el cáculo de donde se tiene que poner la cámara con respecto al jugador se hace 
    //despues de que se hayan ejecutado los updates. LateUpdate se ejecuta justo despues de todos los updates.
    //Se ejecuta cada frame igual que update
    void LateUpdate()
    {
        //transform.position = jugador.transform.position + offset;
    }

    // Método para cambiar la altura de la cámara sin perder el seguimiento
    public void CambiarAltura(float nuevaAltura)
    {
        offset.y = nuevaAltura - jugador.transform.position.y; // Ajusta solo la altura, manteniendo la distancia en x y z
    }
}
