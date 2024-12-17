using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI
using UnityEngine.SceneManagement; // Si necesitas cambiar de escena
using TMPro; // Necesario para trabajar con TextMeshPro


public class CargarFase02 : MonoBehaviour
{
    public Button boton; // El botón de pausa en la UI
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Asegúrate de que el botón esté asignado en el Inspector
        boton.onClick.AddListener(CargarEscena); // Asocia la función al clic del botón
        ManagerPuntos.instance.puntuacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla P para alternar pausa
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarEscena();
        }
    }

    public void CargarEscena()
    {
        SceneManager.LoadScene("Fase_02");
    }
}


