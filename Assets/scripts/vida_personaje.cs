using UnityEngine;

public class Vida_personaje : MonoBehaviour
{
    public int vida_maxima = 100;
    public int vida_actual;

    void Start()
    {
        vida_actual = vida_maxima;
    }

    public void RecibirDanio(int cantidad)
    {
        vida_actual -= cantidad;
        vida_actual = Mathf.Clamp(vida_actual, 0, vida_maxima);

        Debug.Log(gameObject.name + " recibió daño. Vida actual: " + vida_actual);

        if (vida_actual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(gameObject.name + " murió");
        gameObject.SetActive(false);
    }
}

