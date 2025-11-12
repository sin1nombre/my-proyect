using UnityEngine;

public class movimiento_jugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerza_salto = 7f;
    public float control_aereo = 0.5f;
    public int saltos_maximos = 2;
    // -----------------------------
    private Rigidbody2D rb;
    private bool en_suelo;
    private int contador_saltos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        contador_saltos = saltos_maximos;
    }

    void Update()
    {
        float mover = Input.GetAxis("Horizontal");
        float velocidad_actual = en_suelo ? velocidad : velocidad * control_aereo;

        rb.linearVelocity = new Vector2(mover * velocidad_actual, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && contador_saltos > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerza_salto);
            contador_saltos--;
        }

        if (en_suelo)
        {
            contador_saltos = saltos_maximos; // reinicia al tocar el suelo
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            en_suelo = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            en_suelo = false;
    }
}
