using UnityEngine;

//Este script hace que el objeto gire continuamente en los ejes X, Y y Z con velocidades de 15, 30 y 45 grados por segundo, respectivamente.
//Al multiplicar por Time.deltaTime, el objeto girará de manera consistente sin importar la velocidad del juego o la cantidad de fotogramas por segundo.


//MonoBehaviour es la clase base de todos los scripts en Unity que se adjuntan a los objetos 
public class RotacionCubo : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(new Vector3(45, 45, 45));
    }

        // Update is called once per frame
    void Update()
    {
        // en cada fotograma, el objeto rotará 15 grados alrededor del eje X, 30 grados alrededor del eje Y y 45 grados alrededor del eje Z.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        //Time.deltaTime es un valor que representa el tiempo que ha pasado desde el último fotograma.
        //Esto es importante para hacer que la rotación sea independiente de la tasa de fotogramas (frames per second o FPS).
        //Usar Time.deltaTime asegura que el objeto gire a una velocidad constante, sin importar si el juego se ejecuta a 30, 60 o cualquier otra cantidad de fotogramas por segundo.
    }
}
