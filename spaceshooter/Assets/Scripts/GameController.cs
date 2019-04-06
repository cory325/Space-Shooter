using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text PointsText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text createText;

    private bool restart;
    private bool gameOver;
    private int Points;

    void Start()
        {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        createText.text = "";
        Points = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());
        }

    void Update ()
    {
        SceneManager.LoadScene("spaceshooter");
        {
            if (Input.GetKeyDown (KeyCode.Q))
            {
                Application.LoadLevel (Application.loadedLevel);
            }

            if(Input.GetKey("escape"))
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves ()
    {
       yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' for Restart";
                restart = true;
                break;

            }
        }

    }

    public void AddScore (int newScoreValue)
    {
        Points += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        PointsText.text = "Points: " + Points;
        if (Points >= 100)
        {
            winText.text = "You win!";
            createText.text = "Game created by Cory Callander!";
            gameOver = true;
            restart = true;
        }

    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }



}

