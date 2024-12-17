using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI
using UnityEngine.SceneManagement; // Si necesitas cambiar de escena
using TMPro; // Necesario para trabajar con TextMeshPro

public class Pausar : MonoBehaviour
{
    public Button botonPausar; // El botón de pausa en la UI
    public TextMeshProUGUI textoBoton; // El texto dentro del botón
    private bool estaPausado = false; // Estado de la pausa

    void Start()
    {
        // Asegúrate de que el botón esté asignado en el Inspector
        botonPausar.onClick.AddListener(TogglePausa); // Asocia la función al clic del botón
        textoBoton.text = "Pausar";
        estaPausado = false;
    }

    void Update()
    {
        // Detecta si se presiona la tecla P para alternar pausa
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePausa();
        }
    }

    public void TogglePausa()
    {
        if (estaPausado)
        {
            // Si está pausado, reanudar el juego
            Time.timeScale = 1f;  // Reanudar el tiempo
            estaPausado = false;  // Cambiar el estado a no pausado
            textoBoton.text = "Pausar"; // Cambiar el texto del botón a Pausar
        }
        else
        {
            // Si no está pausado, pausar el juego
            Time.timeScale = 0f;  // Pausar el tiempo
            estaPausado = true;   // Cambiar el estado a pausado
            textoBoton.text = "Continuar"; // Cambiar el texto del botón a Continuar
        }
    }
}

