using UnityEngine;

public class SaltarRegulable : MonoBehaviour
{
    public float fuerzaSaltoMaxima = 10f;  // Fuerza máxima de salto
    public float tiempoMaximoSalto = 1f;  // Tiempo máximo que puede estar presionada la tecla
    private float fuerzaSalto = 0f;  // Fuerza actual del salto

    private Rigidbody2D rb;
    private bool presionandoTecla = false;

    public LayerMask capaSuelo;
    public bool ensuelo;
    public BoxCollider2D chequearSuelo;

    SonidosManager sonidosManager;


    void Start()
    {
        sonidosManager = FindObjectOfType<SonidosManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        ensuelo = Physics2D.OverlapBox(chequearSuelo.bounds.center, chequearSuelo.bounds.size, 0f, capaSuelo);

        if (Input.GetKey("w") && ensuelo)
        {
            // Si la tecla 'W' está presionada, comienza el salto
            if (!presionandoTecla)
            {
                sonidosManager.ReproducirSonido(sonidosManager.m_Salto);
                presionandoTecla = true;
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSaltoMaxima);  // Salta inmediatamente
            }
            
            // Acumula la fuerza mientras la tecla esté presionada
            if (fuerzaSalto < fuerzaSaltoMaxima)
            {
                fuerzaSalto += Time.deltaTime * (fuerzaSaltoMaxima / tiempoMaximoSalto);
            }
        }
        else if (Input.GetKeyUp("w"))
        {
            // Cuando se suelta la tecla 'W', detener la fuerza hacia arriba
            presionandoTecla = false;
            if (rb.velocity.y > 0)  // Si aún está subiendo, detener el movimiento hacia arriba
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);  // Detener el movimiento hacia arriba
            }
        }
    }
}
