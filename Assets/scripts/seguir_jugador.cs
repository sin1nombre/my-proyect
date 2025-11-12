using UnityEngine;

public class seguir_jugador : MonoBehaviour
{
    public Transform jugador;  // arrastra aquí el jugador en el inspector
    public float suavizado = 5f; // velocidad con la que sigue
    void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 nueva_posicion = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, nueva_posicion, suavizado * Time.deltaTime);
        }
    }
}
