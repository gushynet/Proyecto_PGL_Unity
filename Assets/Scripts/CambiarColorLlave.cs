using UnityEngine;

public class CambiarColorLlave : MonoBehaviour
{
    private Renderer cuboRenderer; // Referencia al componente Renderer del cubo
    private Color colorObjetivo;   // El color que queremos alcanzar
    private Color colorInicial;    // El color inicial
    public float velocidad = 1f;   // Velocidad de transición entre colores

    void Start()
    {
        // Obtén el componente Renderer del cubo
        cuboRenderer = GetComponent<Renderer>();
        // Establece el color inicial (rojo)
        colorInicial = Color.red;
        // Establece el color objetivo (verde)
        colorObjetivo = Color.green;
        // Establece el color inicial en el material
        cuboRenderer.material.color = colorInicial;
    }

    void Update()
    {
        // Interpolar entre el color actual y el color objetivo
        cuboRenderer.material.color = Color.Lerp(cuboRenderer.material.color, colorObjetivo, Time.deltaTime * velocidad);

        // Si el color actual se acerca al color objetivo, cambia el objetivo
        if (Vector4.Distance(cuboRenderer.material.color, colorObjetivo) < 0.1f)
        {
            // Cambia el color objetivo
            colorObjetivo = colorObjetivo == Color.red ? Color.green : Color.red;
        }
    }
}

