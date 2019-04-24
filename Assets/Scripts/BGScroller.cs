using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollspeed;
    public float timesizeZ;
    private GameController gameController;
    private Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;

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
        float newPosition = Mathf.Repeat(Time.time * scrollspeed, timesizeZ);
        transform.position = startposition + Vector3.forward * newPosition;
        if (gameController.getWinner())
        {
            scrollspeed = -10;
        }
    }

}
