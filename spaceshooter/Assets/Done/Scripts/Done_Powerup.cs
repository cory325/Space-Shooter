using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Powerup : MonoBehaviour
{
    public GameObject[] powerUps;
    public Vector3 powerUpValues;
     public int powerUpCount;
     public float powerUpSpawnWait; 
     public float powerUpStartWait;
     public float powerUpWaveWait;
     public bool gameOver;


    public MeshCollider invincible;
    void Start()
    {
        gameOver = false;
        StartCoroutine(PowerUpWaves());
        invincible = GetComponent<MeshCollider>();
    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Power Up")
        {
            invincible.enabled = false;
        }
    }
    IEnumerator PowerUpWaves()
    {
        yield return new WaitForSeconds(powerUpStartWait);
        while (true)
        {
            for (int i = 0; i < powerUpCount; i++)
            {
                GameObject powerUp = powerUps[Random.Range(0, powerUps.Length)];
                Vector3 powerUpPosition = new Vector3(Random.Range(-powerUpValues.x, powerUpValues.x), powerUpValues.y, powerUpValues.z);
                Quaternion powerUpRotation = Quaternion.identity;
                Instantiate(powerUp, powerUpPosition, powerUpRotation);
                yield return new WaitForSeconds(powerUpSpawnWait);
            }
            yield return new WaitForSeconds(powerUpWaveWait);
            if (gameOver == true)
                break;
        }
    }
}
