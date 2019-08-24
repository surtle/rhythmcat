using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    float originalY;

    [SerializeField] float floatStrength;

    // Start is called before the first frame update
    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x,
            this.originalY + (Mathf.Sin(Time.time * 3) * floatStrength));
    }
}
