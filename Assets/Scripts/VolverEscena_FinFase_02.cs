using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolverEscena_FinFase_02 : MonoBehaviour
{
    public Button boton; // El bot�n de pausa en la UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Aseg�rate de que el bot�n est� asignado en el Inspector
        boton.onClick.AddListener(CargarEscena); // Asocia la funci�n al clic del bot�n
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detecta si se presiona la tecla P para alternar pausa
        if (Input.GetKeyDown(KeyCode.V))
        {
            CargarEscena();
        }
    }

    public void CargarEscena()
    {
        SceneManager.LoadScene("Fin_Fase_02");
    }
}
