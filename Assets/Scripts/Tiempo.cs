using TMPro;  // Importar el espacio de nombres necesario
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;  // Referencia al componente TextMeshProUGUI
    private float tiempoTranscurrido = 0f;  // Tiempo transcurrido en segundos
    private int horas,minutos,segundos;
    void Start()
    {
        if (textoTiempo == null)
        {
            Debug.LogError("No se ha asignado el componente TextMeshProUGUI.");
        }
    }

    void Update()
    {
        // Aumentar el tiempo transcurrido
        //tiempoTranscurrido += Time.deltaTime;
        tiempoTranscurrido += ManagerPuntos.instance.TimeTranscurrido;
        ManagerPuntos.instance.tiempoTranscurrido = tiempoTranscurrido;


        // Convertir el tiempo en horas, minutos y segundos
        horas = Mathf.FloorToInt(tiempoTranscurrido / 3600); // 3600 segundos en 1 hora
        minutos = Mathf.FloorToInt((tiempoTranscurrido % 3600) / 60); // Los minutos restantes
        segundos = Mathf.FloorToInt(tiempoTranscurrido % 60); // Los segundos restantes

        // Formatear el tiempo como 00:00:00
        textoTiempo.text = "Tiempo transcurrido: " + string.Format("{0:00}:{1:00}:{2:00}", horas, minutos, segundos);
    }
}


