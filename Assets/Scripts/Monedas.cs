using UnityEngine;

public class Monedas : MonoBehaviour
{
    NivelManager nivelManager;
    SonidosManager sonidosManager;
    public int valorMoneda;
    private void Start()
    {
        sonidosManager = FindObjectOfType<SonidosManager>();
        nivelManager = FindObjectOfType<NivelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sonidosManager.ReproducirSonido(sonidosManager.m_Moneda);
            nivelManager.SumarPuntos(valorMoneda);
            Destroy(gameObject);
        }

    }
}
