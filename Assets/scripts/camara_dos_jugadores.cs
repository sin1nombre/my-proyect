using UnityEngine;

public class Camara_dos_jugadores : MonoBehaviour
{
    public Transform jugador1;
    public Transform jugador2;
    public float suavizado = 3f;
    public float distancia_min = 5f;   

    void LateUpdate()
    {
        if (jugador1 == null || jugador2 == null)
            return;

        Vector3 punto_medio = (jugador1.position + jugador2.position) / 2f;

        punto_medio.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, punto_medio, Time.deltaTime * suavizado);
    }
}

