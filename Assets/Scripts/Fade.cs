using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    Vector2 initPosition;
    Vector2 finalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("instantiated result");
        initPosition = new Vector2(4, -1);
        finalPosition = new Vector2(initPosition.x, initPosition.y + 1);

        transform.position = initPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.03f);

        if(transform.position.y >= finalPosition.y)
        {
            Destroy(this.gameObject);
        }
    }
}
