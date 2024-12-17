using UnityEngine;
using UnityEngine.UI; // Para trabajar con la UI

public class CamaraCambiarZ : MonoBehaviour
{
    private Camera camaraActiva; // Referencia a la cámara principal
    public float incrementoZ = 2f; // Cantidad de incremento o decremento en X
    public Button botonAumentarZ; // Botón para aumentar la X
    public Button botonDisminuirZ; // Botón para disminuir la X

    public Camera camaraMain;  // Referencia a la primera cámara
    public Camera camara01;  // Referencia a la segunda cámara
    public Camera camara02;
    public Camera camara03;


    void Start()
    {
        // Asignar la función a los botones
        botonAumentarZ.onClick.AddListener(AumentarZ);
        botonDisminuirZ.onClick.AddListener(DisminuirZ);


    }

    void Update()
    {
        if (camaraMain.enabled == true)
        {
            camaraActiva = camaraMain;
        }
        else if (camara01.enabled == true)
        {
            camaraActiva = camara01;
        }
        else if (camara02.enabled == true)
        {
            camaraActiva = camara02;
        }
        else if (camara03.enabled == true)
        {
            camaraActiva = camara03;
        }

        // También puedes controlar con teclas del teclado
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AumentarZ();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisminuirZ();
        }


    }


    // Esta función aumenta la posición X de la cámara
    public void AumentarZ()
    {

        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.z += incrementoZ;
        camaraActiva.transform.position = nuevaPosicion;
    }

    // Esta función disminuye la posición X de la cámara
    public void DisminuirZ()
    {
        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.z -= incrementoZ;
        camaraActiva.transform.position = nuevaPosicion;
    }
}
