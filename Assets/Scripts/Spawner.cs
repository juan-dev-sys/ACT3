using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    public float rateSpawn;
    public float alturaMinima;
    public float alturaMaxima;

    private void Start()
    {
        InvokeRepeating("SpawnearPlataforma", 1f, rateSpawn);

    }

    private void SpawnearPlataforma()
    {
        float r = Random.Range(alturaMaxima, alturaMinima);
        Instantiate(objeto, new Vector2(transform.position.x, r), Quaternion.identity);
    }

}
