using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movimientoenemigo : MonoBehaviour
{

    public int speed;

    public int respawn;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);

    }

    void OnTriggerEnter2D(Collider2D other) //Respawnear jugador
    {

        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(respawn);
        }

        if (other.gameObject.CompareTag("pared"))
        {
            Destroy(gameObject);
        }
    }
}