using UnityEngine;

public class movimiento_jugador_2 : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerza_salto = 7f;
    public float control_aereo = 0.5f;
    public int saltos_maximos = 2;
    public Transform objetivo;  
    public Transform punto_ataque;  

    private Rigidbody2D rb;
    private bool en_suelo;
    private int contador_saltos;

    Vector3 escalaBase;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        contador_saltos = saltos_maximos;
        escalaBase = transform.localScale;
    }

    void Update()
    {

        float mover = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) mover = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) mover = 1f;

        float velocidad_actual = en_suelo ? velocidad : velocidad * control_aereo;
        rb.linearVelocity = new Vector2(mover * velocidad_actual, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && contador_saltos > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerza_salto);
            contador_saltos--;
        }

        if (en_suelo)
            contador_saltos = saltos_maximos;

        MirarObjetivo();

        AjustarPuntoAtaque();
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

    void MirarObjetivo()
    {
        if (objetivo == null) return;

        if (objetivo.position.x > transform.position.x)
            transform.localScale = new Vector3(Mathf.Abs(escalaBase.x), escalaBase.y, escalaBase.z);
        else
            transform.localScale = new Vector3(-Mathf.Abs(escalaBase.x), escalaBase.y, escalaBase.z);
    }

    void AjustarPuntoAtaque()
    {
        if (punto_ataque == null) return;

        float lado = transform.localScale.x;
        punto_ataque.localPosition = new Vector3(0.5f * lado, punto_ataque.localPosition.y, 0);
    }
}
