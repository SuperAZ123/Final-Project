using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSlider : MonoBehaviour
{

    public ParticleSystem ps;
    private GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;


            main.startSpeed = new ParticleSystem.MinMaxCurve(3,6);
        
        
    }

}