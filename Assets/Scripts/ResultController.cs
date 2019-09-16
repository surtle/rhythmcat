using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour

    
{
    [SerializeField] TMP_Text score;
    [SerializeField] ScoreController scoreController;


    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreController.getScoreValue().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
