using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerPuntos : MonoBehaviour
{
    public static ManagerPuntos instance; // Singleton (solo una instancia de GameManager)

    public int PuntosNivel01, PuntosNivel02;
    public int puntuacion=0; // Variable de puntuación
    public float tiempoTranscurrido = 0f;  // Tiempo transcurrido en segundos
    public float TiempoNivel01, TiempoNivel02;

    public TextMeshProUGUI textoPuntuacion;

    
    public float TimeTranscurrido
    {
        get
        {
            return Time.deltaTime;
        }
    }

    private void Awake()
    {
        // Comprobar si ya hay una instancia de GameManager
        if (instance == null)
        {
            instance = this; // Asignar esta instancia como la única
            puntuacion = 0;
            PuntosNivel01 = 0;
            PuntosNivel02 = 0;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe un GameManager, destruir el nuevo
        }
    }

    // Método para aumentar la puntuación
    public void IncrementarPuntuacion(int puntos)
    {
        puntuacion += puntos;

        Scene EscenaActiva = SceneManager.GetActiveScene();

        if(EscenaActiva != null)
        {
            if(EscenaActiva.name == "Fase_01")
            {
                PuntosNivel01 += puntos;
            }
            else if (EscenaActiva.name == "Fase_02")
            {
                PuntosNivel02 += puntos;
            }
        }

        Debug.Log("Puntuación actual: " + puntuacion);
    }

    
}

