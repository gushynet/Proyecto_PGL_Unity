using NUnit.Framework;
using TMPro;
using UnityEngine;

public class LogrosFase_01 : MonoBehaviour
{
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoTiempo;

    private int horas, minutos, segundos;
    private float tiempoTranscurrido = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        textoPuntos.text = "Puntuación: " + ManagerPuntos.instance.puntuacion.ToString();

        //tiempoTranscurrido += ManagerPuntos.instance.tiempoTranscurrido;
        tiempoTranscurrido += ManagerPuntos.instance.TiempoNivel01;

        horas = Mathf.FloorToInt(tiempoTranscurrido / 3600); // 3600 segundos en 1 hora
        minutos = Mathf.FloorToInt((tiempoTranscurrido % 3600) / 60); // Los minutos restantes
        segundos = Mathf.FloorToInt(tiempoTranscurrido % 60); // Los segundos restantes

        // Formatear el tiempo como 00:00:00
        textoTiempo.text = "Tiempo transcurrido: " + string.Format("{0:00}:{1:00}:{2:00}", horas, minutos, segundos);
    }

    
}
