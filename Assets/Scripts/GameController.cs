using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardcount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float soundDelay;
    public float timer;
    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text CreatorText;
    private bool gameover;
    private bool restart;
    private bool winner;
    private bool power;
    private int score;
    public AudioSource musicSource;
    public AudioClip defeatclip; 
    public AudioClip victoryclip;



    void Start()
    {
        score = 0;
        gameover = false;
        winner = false;
        restart = false;
        power = false;
        RestartText.text = "";
        GameOverText.text = "";
        CreatorText.text = "";
        UpdateScore();
        StartCoroutine (SpawnWaves());  
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Challenge Final");
            }
        }

        if (power)
        {
            StartCoroutine(Duration());
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardcount; i++)

            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                RestartText.text = "Press 'P' for restart";
                restart = true;
                break;
            }
        }

    }

    public void addScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;

        if (score >= 100)
        {
            GameOverText.text = "You Win!";
            CreatorText.text = "Game Created By Akinyele Zahira";
            musicSource.clip = victoryclip;
            musicSource.loop = false;
            musicSource.Play();
            gameover = true;
            winner = true;
        }
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        musicSource.clip = defeatclip;
        musicSource.loop = false;
        StartCoroutine(Delay());
        gameover = true;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(soundDelay);
        musicSource.Play();
    }

    private IEnumerator Duration()
    {
        yield return new WaitForSeconds(timer);
        power = false;
    }

    public bool getWinner()
    {
        return winner;
    }

    public void setPower(bool powerup)
    {
        power = powerup;
    }
     
    public bool getPower()
    {
        return power;
    }
}
