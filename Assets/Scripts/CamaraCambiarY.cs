using UnityEngine;
using UnityEngine.UI; // Para trabajar con la UI

public class CamaraCambiarY : MonoBehaviour
{
    private Camera camaraActiva; // Referencia a la cámara principal
    public float incrementoY = 2f; // Cantidad de incremento o decremento en X
    public Button botonAumentarY; // Botón para aumentar la X
    public Button botonDisminuirY; // Botón para disminuir la X

    public Camera camaraMain;  // Referencia a la primera cámara
    public Camera camara01;  // Referencia a la segunda cámara
    public Camera camara02;
    public Camera camara03;


    void Start()
    {
        // Asignar la función a los botones
        botonAumentarY.onClick.AddListener(AumentarY);
        botonDisminuirY.onClick.AddListener(DisminuirY);


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
            AumentarY();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisminuirY();
        }


    }


    // Esta función aumenta la posición X de la cámara
    public void AumentarY()
    {

        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.y += incrementoY;
        camaraActiva.transform.position = nuevaPosicion;
    }

    // Esta función disminuye la posición X de la cámara
    public void DisminuirY()
    {
        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.y -= incrementoY;
        camaraActiva.transform.position = nuevaPosicion;
    }
}
