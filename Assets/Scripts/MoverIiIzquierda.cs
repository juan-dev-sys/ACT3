using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MoverIiIzquierda : MonoBehaviour
{
    public float velocidadDesplazamiento;
    Rigidbody2D rb;
    NivelManager nivelManager;
    private void Start()
    {
        nivelManager = FindObjectOfType<NivelManager>();
        velocidadDesplazamiento = nivelManager.VelocidadJuego;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity =  velocidadDesplazamiento * Vector2.left;
    }
}
