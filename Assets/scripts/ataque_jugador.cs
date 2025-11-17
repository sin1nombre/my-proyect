using UnityEngine;

public class Ataque_jugador : MonoBehaviour
{
    [Header("Controles")]
    public KeyCode tecla_ataque = KeyCode.F;

    [Header("Ataque")]
    public Transform punto_ataque;
    public float radio_ataque = 0.5f;
    public int danio_ataque = 10;
    public float tiempo_entre_ataques = 0.3f;

    [Header("Dirección del jugador")]
    public Transform objetivo; // El otro jugador

    private float tiempo_siguiente_ataque = 0f;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MirarObjetivo();

        if (Time.time >= tiempo_siguiente_ataque)
        {
            if (Input.GetKeyDown(tecla_ataque))
            {
                Atacar();
                tiempo_siguiente_ataque = Time.time + tiempo_entre_ataques;
            }
        }
    }

    void MirarObjetivo()
    {
        if (objetivo == null) return;

        // Si el enemigo está a la derecha → mirar derecha
        if (objetivo.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            punto_ataque.localPosition = new Vector3(+0.5f, 0, 0);
        }
        else
        {
            // Si está a la izquierda → mirar izquierda
            transform.localScale = new Vector3(-1, 1, 1);
            punto_ataque.localPosition = new Vector3(-0.5f, 0, 0);
        }
    }

    void Atacar()
    {
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(
            punto_ataque.position,
            radio_ataque
        );

        foreach (Collider2D enemigo in enemigos)
        {
            Vida_personaje vida = enemigo.GetComponent<Vida_personaje>();
            if (vida != null)
            {
                vida.RecibirDanio(danio_ataque);
            }
        }

        Debug.Log(gameObject.name + " atacó.");
    }

    void OnDrawGizmosSelected()
    {
        if (punto_ataque == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(punto_ataque.position, radio_ataque);
    }
}
