using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour

{

    private TMP_Text scoreText;
    static int scoreValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScoreValue(int score)
    {
        scoreValue = score;
        Debug.Log("scoreController: " + score.ToString());
    }

    public int getScoreValue()
    {
        return scoreValue;
    }
}
