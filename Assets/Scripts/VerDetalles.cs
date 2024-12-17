using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI
using UnityEngine.SceneManagement; // Si necesitas cambiar de escena
using TMPro; // Necesario para trabajar con TextMeshPro

public class VerDetalles : MonoBehaviour
{
    public Button boton; // El botón de pausa en la UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boton.onClick.AddListener(MostrarDetalles);
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla P para alternar pausa
        if (Input.GetKeyDown(KeyCode.D))
        {
            MostrarDetalles();
        }
    }

    public void MostrarDetalles()
    {
        SceneManager.LoadScene("Detalles");
    }
}
