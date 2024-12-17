using UnityEngine;

public class Saltar : MonoBehaviour
{
    public float fuerzaSalto = 10f;  // La fuerza que se aplicará para hacer saltar a la esfera
    private Rigidbody rb;            // Referencia al Rigidbody de la esfera
    private bool enElSuelo = true;   // Para asegurarse de que la esfera no salte en el aire

    void Start()
    {
        // Obtener el Rigidbody de la esfera
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verifica si la tecla de espacio es presionada y si la esfera está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            Salto();
        }
    }

    void Salto()
    {
        // Aplica una fuerza hacia arriba para hacer saltar la esfera
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        enElSuelo = false;  // Desactivar la posibilidad de saltar hasta que vuelva al suelo
    }

    // Detecta si la esfera está tocando el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;  // La esfera puede saltar nuevamente cuando toca el suelo
        }
    }
}

