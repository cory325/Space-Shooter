using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;
    private Done_GameController gameControllerObj;

    void Start ()
	{
		startPosition = transform.position;

        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<Done_GameController>();

    }

    void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;

        if (gameControllerObj.winCondition == true)
        {
            if (scrollSpeed>= -15)
            {
                scrollSpeed -= Time.deltaTime;
            }
        }


    }
}