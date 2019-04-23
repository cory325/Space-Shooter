using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Stars : MonoBehaviour
{
    private Done_GameController gameControllerObj;

    private ParticleSystem ps;
    private float hSliderValue = 1.0F;

    public float scrollSpeed;

    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<Done_GameController>();

        ps = GetComponent<ParticleSystem>();

    }

    void Update()
    {

        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (gameControllerObj.winCondition == true)
        {
            if (hSliderValue <= 15)
            {
                hSliderValue += Time.deltaTime;
            }
        }


        if (gameControllerObj.winCondition == true)
        {
            if (scrollSpeed >= -15)
            {
                scrollSpeed -= Time.deltaTime;
            }
        }
    }
}

