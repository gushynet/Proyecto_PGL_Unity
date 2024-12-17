using UnityEngine;
using UnityEngine.UI;

public class CambiarCamara : MonoBehaviour
{
    public Camera camaraMain;  // Referencia a la primera cámara
    public Camera camara01;  // Referencia a la segunda cámara
    public Camera camara02;
    public Camera camara03;

    public Button BotonCamaraMain,BotonC1,BotonC2,BotonC3;

    void Start()
    {
        // Asegúrate de que solo una cámara esté activa al principio
        camaraMain.enabled = true;  // Activar la cámara 1
        camara01.enabled = false; // Desactivar la cámara 2
        camara02.enabled = false;
        camara03.enabled = false;

        BotonCamaraMain.onClick.AddListener(SetCamaraMain);
        BotonC1.onClick.AddListener(SetCamara01);
        BotonC2.onClick.AddListener(SetCamara02);
        BotonC3.onClick.AddListener(SetCamara03);
    }

    
    void Update()
    {
        // Cambiar entre las cámaras al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetCamaraMain();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))//tecla 1
        {
            SetCamara01();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))//tecla 2
        {
            SetCamara02();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))//tecla 3
        {
            SetCamara03();
        }
    }
    private void SetCamaraMain()
    {
        camaraMain.enabled = true;
        camara01.enabled = false;
        camara02.enabled = false;
        camara03.enabled = false;
    }

    private void SetCamara01()
    {
        camaraMain.enabled = false;
        camara01.enabled = true;
        camara02.enabled = false;
        camara03.enabled = false;
    }

    private void SetCamara02()
    {
        camaraMain.enabled = false;
        camara01.enabled = false;
        camara02.enabled = true;
        camara03.enabled = false;
    }

    private void SetCamara03()
    {
        camaraMain.enabled = false;
        camara01.enabled = false;
        camara02.enabled = false;
        camara03.enabled = true;
    }

   
}

