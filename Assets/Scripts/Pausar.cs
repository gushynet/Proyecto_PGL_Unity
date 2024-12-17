using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI
using UnityEngine.SceneManagement; // Si necesitas cambiar de escena
using TMPro; // Necesario para trabajar con TextMeshPro

public class Pausar : MonoBehaviour
{
    public Button botonPausar; // El bot�n de pausa en la UI
    public TextMeshProUGUI textoBoton; // El texto dentro del bot�n
    private bool estaPausado = false; // Estado de la pausa

    void Start()
    {
        // Aseg�rate de que el bot�n est� asignado en el Inspector
        botonPausar.onClick.AddListener(TogglePausa); // Asocia la funci�n al clic del bot�n
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
            // Si est� pausado, reanudar el juego
            Time.timeScale = 1f;  // Reanudar el tiempo
            estaPausado = false;  // Cambiar el estado a no pausado
            textoBoton.text = "Pausar"; // Cambiar el texto del bot�n a Pausar
        }
        else
        {
            // Si no est� pausado, pausar el juego
            Time.timeScale = 0f;  // Pausar el tiempo
            estaPausado = true;   // Cambiar el estado a pausado
            textoBoton.text = "Continuar"; // Cambiar el texto del bot�n a Continuar
        }
    }
}

