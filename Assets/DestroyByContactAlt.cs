using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactAlt : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private int hitcount;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }

        hitcount = Random.Range(5, 11);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }


        if (hitcount > 1)
        {
            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }

            Destroy(other.gameObject);
            hitcount--;
        }

        
        else if (hitcount == 1)
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }


            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.addScore(scoreValue);
        }

        if (other.CompareTag("SuperShot"))
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.addScore(scoreValue);
        }
    }
        
}
