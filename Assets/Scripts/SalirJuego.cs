using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI
using UnityEngine.SceneManagement; // Si necesitas cambiar de escena
using TMPro; // Necesario para trabajar con TextMeshPro


public class SalirJuego : MonoBehaviour
{
    public Button boton; // El botón de pausa en la UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Asegúrate de que el botón esté asignado en el Inspector
        boton.onClick.AddListener(Salir); // Asocia la función al clic del botón

    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla P para alternar pausa
        if (Input.GetKeyDown(KeyCode.C))
        {
            Salir();
        }
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego..."); // Para pruebas en Unity Editor
        Application.Quit();//no funciona en el Unity Editor, pero sí en la aplicación final (EXE, APK, etc.).
    }
}
