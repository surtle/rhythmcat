using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{

    // curr position of the song (in secs)
    float songPosition;

    // curr position of the song (in beats)
    float songPosInBeats;

    // duration of a beat
    float secPerBeat;

    // time elapsed since song played (in secs)
    float timeElapsed;

    // beats per minute of song
    float bpm = 50;

    // keep position-in-beats of notes in the song
    float[] notes = { 5, 6, 7.5f, 8, 9, 10, 10.5f, 12, 12.5f, 13, 13.5f, 14.5f, 15.5f, 16.5f };

    // index of the next note to be spawned
    int nextIndex;

    // number of beats to show in advance
    int beatsShownInAdvance;

    [SerializeField] KeyGenerator keyGenerator;

    // Start is called before the first frame update
    void Start()
    {
        // calculate beat duration
        secPerBeat = 60f / bpm;

        // initialize with the time when song starts 
        timeElapsed = (float) AudioSettings.dspTime;

        beatsShownInAdvance = 4;

        // play song
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the position in seconds
        songPosition = (float) (AudioSettings.dspTime - timeElapsed);

        // calculate the position in beats 
        songPosInBeats = songPosition / secPerBeat;
        Key.updateCurrSongPos(songPosInBeats);

        if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats + beatsShownInAdvance)
        {
            Debug.Log("generating new note");
            keyGenerator.generateNewKey(beatsShownInAdvance, notes[nextIndex]);
            nextIndex++;
        }
    }
}
