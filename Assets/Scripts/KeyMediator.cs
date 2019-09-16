using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyMediator : MonoBehaviour
{

    [SerializeField] KeyGenerator keyGen;
    [SerializeField] TMP_Text score;
    [SerializeField] ResultView rv;
    [SerializeField] ScoreController scoreController;

    private Vector2 keyCatcherPos;
    int scoreValue;

    float perfectRange = 0.08f;
    float okRange = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        keyCatcherPos = this.transform.position;
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            int activeKeyID = keyGen.getActiveKey().getKeyID();
            Vector2 keyPos = keyGen.getActiveKey().transform.position;

            // remove active key if it passes the key catcher
            if (keyPos.x > 5)
            {
                keyGen.destroyKey();
            }

            // calculate score 
            if (activeKeyID == 0 && Input.GetKeyDown(KeyCode.A))
            {
                scoreValue += calculateScore(keyPos.x, keyCatcherPos.x);
                keyGen.destroyKey();
                Debug.Log(scoreValue);
            }
            else if (activeKeyID == 1 && Input.GetKeyDown(KeyCode.S))
            {
                scoreValue += calculateScore(keyPos.x, keyCatcherPos.x);
                keyGen.destroyKey();
                Debug.Log(scoreValue);
            }
            else if (activeKeyID == 2 && Input.GetKeyDown(KeyCode.K))
            {
                scoreValue += calculateScore(keyPos.x, keyCatcherPos.x);
                keyGen.destroyKey();
                Debug.Log(scoreValue);
            }
            else if (activeKeyID == 3 && Input.GetKeyDown(KeyCode.L))
            {
                scoreValue += calculateScore(keyPos.x, keyCatcherPos.x);
                keyGen.destroyKey();
                Debug.Log(scoreValue);
            }
            else if (Input.anyKeyDown)
            {
                scoreValue -= 100;
            }

            // update score
            score.text = scoreValue.ToString().PadLeft(4, '0');
            scoreController.setScoreValue(scoreValue);
            
        } catch
        {
            // do ntohing? 
        }
    }

    int calculateScore(float distance1, float distance2)
    {
        Debug.Log(Mathf.Abs(distance1 - distance2));
        if(Mathf.Abs(distance1 - distance2) <= perfectRange)
        {
            rv.showPerfectResult();
            return 100;
        }
        else if(Mathf.Abs(distance1 - distance2) <= okRange)
        {
            rv.showOKResult();
            return 50;
        }
        else
        {
            return -50;
        }
    }

}
