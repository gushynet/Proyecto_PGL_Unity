using UnityEngine;
using UnityEngine.UI; // Para trabajar con la UI

public class CamaraCambiarX : MonoBehaviour
{
    private Camera camaraActiva; // Referencia a la c�mara principal
    public float incrementoX = 2f; // Cantidad de incremento o decremento en X
    public Button botonAumentarX; // Bot�n para aumentar la X
    public Button botonDisminuirX; // Bot�n para disminuir la X

    public Camera camaraMain;  // Referencia a la primera c�mara
    public Camera camara01;  // Referencia a la segunda c�mara
    public Camera camara02;
    public Camera camara03;


    void Start()
    {
        // Asignar la funci�n a los botones
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

        // Tambi�n puedes controlar con teclas del teclado
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AumentarX();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisminuirX();
        }


    }


    // Esta funci�n aumenta la posici�n X de la c�mara
    public void AumentarX()
    {

        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.x += incrementoX;
        camaraActiva.transform.position = nuevaPosicion;
    }

    // Esta funci�n disminuye la posici�n X de la c�mara
    public void DisminuirX()
    {
        Vector3 nuevaPosicion = camaraActiva.transform.position;
        nuevaPosicion.x -= incrementoX;
        camaraActiva.transform.position = nuevaPosicion;
    }
}
