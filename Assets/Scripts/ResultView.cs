using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultView : MonoBehaviour
{

    [SerializeField] GameObject okResult;
    [SerializeField] GameObject perfectResult;

    Vector2 originalPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showOKResult()
    {
        GameObject okRes = Instantiate(okResult);
    }

    public void showPerfectResult()
    {
        GameObject perfRes = Instantiate(perfectResult);
    }
}
