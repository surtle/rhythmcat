using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{

    [SerializeField] KeyMediator km;
    [SerializeField] GameObject keyPrefab;

    System.Random rd = new System.Random();

    int beatsShownInAdvance;
    float beatOfThisNote;
    float songPosInBeats; 

    Vector2 initPos;

    Queue<GameObject> activeKeys = new Queue<GameObject>();
    
    void Awake()
    {
        initPos = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateNewKey(int bia, float bon)
    {
        GameObject note = Instantiate(keyPrefab);
        activeKeys.Enqueue(note);

        // initialize values of note
        Key key = note.GetComponent<Key>();
        key.setBeatOfNote(bon);
        key.setBeatsShownInAdvance(bia);

    }

    public Key getActiveKey()
    {
        try
        {
            return activeKeys.Peek().GetComponent<Key>();
        } catch
        {
            throw;
        }
    }

    public Vector2 getPos()
    {
        return this.transform.position;
    }

    public void destroyKey()
    {
        getActiveKey().removeSprite();
        activeKeys.Dequeue();

    }
}
