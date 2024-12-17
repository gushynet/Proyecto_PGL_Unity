using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextoFlotante : MonoBehaviour
{
    public float moveSpeed = 1f;      // Velocidad a la que se eleva el texto
    public float fadeDuration = 1f;   // Duración de la animación de desvanecimiento

    private Text text;                // Referencia al componente Text
    private Color originalColor;      // Color original del texto

    void Start()
    {
        text = GetComponent<Text>();             // Obtenemos el componente Text
        originalColor = text.color;              // Guardamos el color original
    }

    public void StartFloating()
    {
        StartCoroutine(FloatingTextCoroutine());
    }

    private IEnumerator FloatingTextCoroutine()
    {
        Vector3 initialPosition = transform.position; // Posición inicial
        float elapsedTime = 0f;

        // Eleva el texto
        while (elapsedTime < fadeDuration)
        {
            transform.position = initialPosition + new Vector3(0, moveSpeed * elapsedTime, 0);
            float alpha = Mathf.Lerp(originalColor.a, 0, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Elimina el texto flotante cuando haya desaparecido
        Destroy(gameObject);
    }
}

