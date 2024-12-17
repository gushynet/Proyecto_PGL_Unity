using UnityEngine;
using UnityEngine.UI; // Para trabajar con la UI

public class CamaraCambiarX : MonoBehaviour
{
    private Camera camaraActiva; // Referencia a la cámara principal
    public float incrementoX = 2f; // Cantidad de incremento o decremento en X
    public Button botonAumentarX; // Botón para aumentar la X
    public Button botonDisminuirX; // Botón para disminuir la X

    public Camera camaraMain;  // Referencia a la primera cámara
    public Camera camara01;  // Referencia a la segunda cámara
    public Camera camara02;
    public Camera camara03;


    void Start()
    {
        // Asignar la función a los botones
        botonAumentarX.onClick.AddListener(AumentarX);
        botonDisminuirX.onClick.AddListener(DisminuirX);
       
       
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
            AumentarX();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisminuirX();
        }


    }


    // Esta función aumenta la posición X de la cámara
    public void AumentarX()
    {

        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.x += incrementoX;
        camaraActiva.transform.position = nuevaPosicion;
    }

    // Esta función disminuye la posición X de la cámara
    public void DisminuirX()
    {
        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.x -= incrementoX;
        camaraActiva.transform.position = nuevaPosicion;
    }
}
