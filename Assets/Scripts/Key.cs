using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    static float songPosInBeats;
    float beatOfThisNote;
    int beatsShownInAdvance;

    int keyID;

    [SerializeField] Sprite a_texture;
    [SerializeField] Sprite s_texture;
    [SerializeField] Sprite k_texture;
    [SerializeField] Sprite l_texture;

    // starting and ending locations for each key
    Vector2 initPos = new Vector2(-7.2f, -2.5f);
    Vector2 catcherPos = new Vector2(4, -2.5f);
    Vector2 finalPos = new Vector2(7.2f, -2.5f);

    SpriteRenderer sr;

    List<Sprite> sprites;
    System.Random rd = new System.Random();
 
    // Start is called before the first frame update
    void Start()
    {
        sprites = new List<Sprite>() { a_texture, s_texture, k_texture, l_texture };
        sr = GetComponent<SpriteRenderer>();
        keyID = rd.Next(0, sprites.Count);

        // assign random sprite
        sr.sprite = sprites[keyID];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < catcherPos.x)
        {
            transform.position = Vector2.Lerp(initPos, catcherPos,
                (beatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / beatsShownInAdvance);
        } else
        {
            transform.position = new Vector2(transform.position.x + 0.03f, transform.position.y);
        }
            
    }

    public static void updateCurrSongPos(float currPos)
    {
        songPosInBeats = currPos;
    }

    public void setBeatOfNote(float beatOfThisNote)
    {
        this.beatOfThisNote = beatOfThisNote;
    }

    public void setBeatsShownInAdvance(int beatsShownInAdvance)
    {
        this.beatsShownInAdvance = beatsShownInAdvance;
    }

    public int getKeyID()
    {
        return keyID;
    }

    public void removeSprite()
    {
        sr.sprite = null;
    }
}
