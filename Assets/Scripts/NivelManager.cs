using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelManager : MonoBehaviour
{
    public int puntaje;
    public int mejorPuntaje;

    public int VelocidadJuego;

    [SerializeField] TextMeshProUGUI txtPuntaje;
    [SerializeField] TextMeshProUGUI txtMejorPuntje;

    private void Start()
    {
        // Cargar el mejor puntaje al iniciar
        mejorPuntaje = PlayerPrefs.GetInt("MejorPuntaje", 0);
    }

    private void Update()
    {
        txtPuntaje.text = "PUNTAJE : " + puntaje.ToString();
        txtMejorPuntje.text = "MEJOR PUNTAJE : " + mejorPuntaje.ToString();
    }

    public void SumarPuntos(int punto)
    {
        puntaje += punto;

        if (puntaje > mejorPuntaje)
        {
            mejorPuntaje = puntaje;

            // Guardar el nuevo mejor puntaje
            PlayerPrefs.SetInt("MejorPuntaje", mejorPuntaje);
            PlayerPrefs.Save(); // Opcional, asegura que se guarde inmediatamente
        }
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    [ContextMenu("Reiniciar Mejor Puntaje")]
    public void ReiniciarMejorPuntaje()
    {
        PlayerPrefs.DeleteKey("MejorPuntaje");
        mejorPuntaje = 0;
    }
}
