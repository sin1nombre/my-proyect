using UnityEngine;

public class Ataque_jugador : MonoBehaviour
{
    public Transform punto_ataque;
    public float radio_ataque = 0.5f;
    public int danio_ataque = 10;
    public LayerMask capas_enemigos;
    public float tiempo_entre_ataques = 0.3f;

    private float tiempo_siguiente_ataque = 0f;

    void Update()
    {
        // Bloqueamos el spam de ataques muy seguidos
        if (Time.time >= tiempo_siguiente_ataque)
        {
            // Puedes usar Fire1 (click / Ctrl) o una tecla fija como J
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.J))
            {
                Atacar();
                tiempo_siguiente_ataque = Time.time + tiempo_entre_ataques;
            }
        }
    }

    void Atacar()
    {
        // Buscar todos los colliders en el radio del ataque que estén en la capa de enemigos
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(punto_ataque.position, radio_ataque, capas_enemigos);

        foreach (Collider2D enemigo in enemigos)
        {
            Vida_personaje vida = enemigo.GetComponent<Vida_personaje>();
            if (vida != null)
            {
                vida.RecibirDanio(danio_ataque);
            }
        }

        Debug.Log("Jugador realizó un ataque.");
    }

    void OnDrawGizmosSelected()
    {
        if (punto_ataque == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(punto_ataque.position, radio_ataque);
    }
}

