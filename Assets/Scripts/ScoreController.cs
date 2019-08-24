using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour

{

    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        Debug.Log(scoreText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
