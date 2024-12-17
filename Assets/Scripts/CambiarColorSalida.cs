using UnityEngine;

public class CambiarColorSalida : MonoBehaviour
{
    public Renderer quadRenderer; // El Renderer del Quad
    public float velocidadCambio = 10.0f; // Velocidad con la que cambia el color
    private float tiempo = 0f;

    // Colores brillantes y psicodélicos
    private Color[] coloresPsicodelicos = new Color[] {
        new Color(1f, 0f, 0f),   // Rojo brillante
        new Color(0f, 1f, 0f),   // Verde brillante
        new Color(0f, 0f, 1f),   // Azul brillante
        new Color(1f, 1f, 0f),   // Amarillo brillante
        new Color(1f, 0f, 1f),   // Magenta brillante
        new Color(0f, 1f, 1f),   // Cian brillante
        new Color(1f, 0.5f, 0f)  // Naranja brillante
    };

    void Start()
    {
        // Asegúrate de que el Renderer esté asignado
        if (quadRenderer == null)
        {
            quadRenderer = GetComponent<Renderer>();
        }
    }

    void Update()
    {
        // Incrementar el tiempo
        tiempo += Time.deltaTime * velocidadCambio;

        // Cambiar el color aleatoriamente entre los colores psicodélicos
        Color colorAleatorio = coloresPsicodelicos[Random.Range(0, coloresPsicodelicos.Length)];

        // Aplicar el color aleatorio al material del Quad
        quadRenderer.material.color = colorAleatorio;

        // Hacer que el cambio de color ocurra rápidamente para simular el "ruido"
        if (tiempo > 0.1f) // Cambiar la frecuencia con la que el color cambia
        {
            tiempo = 0f;
        }
    }
}


