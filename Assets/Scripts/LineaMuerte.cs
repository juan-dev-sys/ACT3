using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineaMuerte : MonoBehaviour
{
    SonidosManager sonidosManager;

    private void Start()
    {
       sonidosManager = FindObjectOfType<SonidosManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ReiniciarNivel());
    }

    IEnumerator ReiniciarNivel()
    {
        sonidosManager.SonidoMuerte();
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Nivel1");
    }
}
