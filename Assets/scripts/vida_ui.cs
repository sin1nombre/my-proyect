using UnityEngine;
using UnityEngine.UI;

public class Vida_ui : MonoBehaviour
{
    public Vida_personaje vida;
    public Image barra_roja;
    public Image barra_amarilla;
    public float velocidad_retraso = 0.5f;

    private float vida_normalizada;

    void Update()
    {
        if (vida == null) return;

        vida_normalizada = (float)vida.vida_actual / vida.vida_maxima;

        barra_roja.fillAmount = vida_normalizada;

        // Barra amarilla se actualiza lentamente (delay clásico de MK)
        if (barra_amarilla.fillAmount > barra_roja.fillAmount)
        {
            barra_amarilla.fillAmount -= Time.deltaTime * velocidad_retraso;
        }
        else
        {
            barra_amarilla.fillAmount = barra_roja.fillAmount;
        }
    }
}
