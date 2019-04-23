using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public bool winCondition;
   
    public Text pointsText;
    public Text restartText;
    public Text gameOverText;
    public Text createText;
    public Text winText;
    public Text hardText;

    private bool gameOver;
    private bool restart;
    private int points;

    private AudioSource audioSource;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioClip mainMusic;



    void Start()
    {
        gameOver = false;
        restart = false;
        winCondition = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        createText.text = "";
        points = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        audioSource.clip = mainMusic;
        audioSource.Play();
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("Done_Main");
            }

        }
        if (Input.GetKey("escape"))
            Application.Quit();

        {
            if (points >= 100)
            {
                audioSource.clip = winMusic;
                audioSource.Play();
            }
        }

  

    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
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

    public void AddScore(int newScoreValue)
    {

        points += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
        {
            pointsText.text = "Points: " + points;
            if (points >= 200)
            {
                winText.text = "You win!";
                createText.text = "Game Created By Cory";
                gameOver = true;
                restart = true;
            winCondition = true;
            }

        
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        audioSource.clip = loseMusic;
        audioSource.Play();
    }
}