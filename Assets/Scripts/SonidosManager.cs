using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosManager : MonoBehaviour
{
    [SerializeField] AudioSource m_SFX;
    [SerializeField] AudioSource m_Musica;

    [SerializeField] public AudioClip m_Salto;
    [SerializeField] public AudioClip m_Moneda;
    [SerializeField] public AudioClip m_Muerte;

    public void ReproducirSonido(AudioClip clip)
    {
        m_SFX.PlayOneShot(clip);
    }

    public void SonidoMuerte()
    {
        m_Musica.Stop();
        m_Musica.clip = m_Muerte;
        m_Musica.Play();
    }
}
