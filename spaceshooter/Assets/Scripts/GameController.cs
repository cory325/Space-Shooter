using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text createText;
    public Text winText;

    private bool restart;
    private bool gameOver;
    private int score;

    void Start()
        {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        createText.text = "";
        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());
        }

    void Update ()
    {
        SceneManager.LoadScene("spaceshooter");
        {
            if (Input.GetKeyDown (KeyCode.Q))
            {

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
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
        if (score >= 200)
        {
            winText.text = "You win!";
            createText.text = "Game Created By Cory";
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

