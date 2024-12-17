using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI
using UnityEngine.SceneManagement; // Si necesitas cambiar de escena
using TMPro; // Necesario para trabajar con TextMeshPro

public class Reiniciar_Nivel_01 : MonoBehaviour
{
    public Button boton; // El botón de pausa en la UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boton.onClick.AddListener(CargarFase01);
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla P para alternar pausa
        if (Input.GetKeyDown(KeyCode.R))
        {
            CargarFase01();
        }
    }

    public void CargarFase01()
    {
        SceneManager.LoadScene("Fase_01");
    }
}
