using UnityEngine;

using UnityEngine;

public class movimiento_jugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerza_salto = 7f;
    private Rigidbody2D cuerpo;
    private bool en_suelo;

    void Start()
    {
        cuerpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float mover = Input.GetAxis("Horizontal");
        cuerpo.linearVelocity = new Vector2(mover * velocidad, cuerpo.linearVelocity.y);

        // Salto
        if (Input.GetButtonDown("Jump") && en_suelo)
        {
            cuerpo.linearVelocity = new Vector2(cuerpo.linearVelocity.x, fuerza_salto);
        }
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Ground"))
            en_suelo = true;
    }

    void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Ground"))
            en_suelo = false;
    }
}
