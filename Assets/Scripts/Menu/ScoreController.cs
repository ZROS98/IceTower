using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int startPlayerPositionY = 11;
    private int score = 0;
    private float currentHight = -11f;
    private float oldHight = -11f;
    private Text scoreText;
    [SerializeField] Transform playerTransform;

    private void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        currentHight = startPlayerPositionY + playerTransform.position.y;

        if (currentHight > oldHight)
        {
            oldHight = currentHight;
            score = (int)oldHight;
            scoreText.text = score.ToString();
        }
    }

    public void RestartScore()
    {
        startPlayerPositionY = 11;
        currentHight = -11f;
        oldHight = -11f;
        score = 0;
        scoreText.text = "0";
    }
}