using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigos : MonoBehaviour
{

    public int respawn;

    public int speed;

    public GameObject paredInvisible;

    public bool resetPosition;

    public GameObject prefabEnemy;

    public int numEnemies;
    int EnemiesSacados;


    // Start is called before the first frame update
    void Start()
    {

        resetPosition = false;
        //  invokeEnemy();
        RepetirCiclo();
    }

    void Update()
    {
        //  transform.Translate(speed*Time.deltaTime,0f,0f);

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
            // resetPosition = true;

        }

    }

    private void OnCollisionEnter2D(Collision colision) //destruir al jugador si éste toca al enemigo
    {
        if (colision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }






    }

    void CrearEnemigo()
    {
        if (EnemiesSacados < numEnemies)
        {
            Instantiate(prefabEnemy, transform.position, transform.rotation);
            EnemiesSacados++;
        }
        else
        {
            CancelInvoke("CrearEnemigo");
            Invoke("RepetirCiclo", 4f);
            EnemiesSacados = 0;
        }
    }

    void RepetirCiclo()
    {
        InvokeRepeating("CrearEnemigo", 0f, 1f);
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //    Destroy(gameObject);

