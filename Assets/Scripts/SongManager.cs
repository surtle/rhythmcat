using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{

    [SerializeField] SceneChanger sc;

    // curr position of the song (in secs)
    float songPosition;

    // curr position of the song (in beats)
    float songPosInBeats;

    // duration of a beat
    float secPerBeat;

    // time elapsed since song played (in secs)
    float timeElapsed;

    // beats per minute of song
    float bpm = 93f;

    // keep position-in-beats of notes in the song
    float[] notes = { 8.25f, 12.25f, 16.25f, 20.25f, 24.25f, 30.25f,
        31.25f, 33.25f, 33.75f, 34.25f, 36.25f, 40.25f, 44.25f, 46.25f,
        48.25f, 50.25f, 52.25f, 54.25f, 58.25f, 60.25f, 62.25f, 64.25f,
        64.75f, 68.25f, 68.75f, 70.25f, 70.75f, 72.25f, 72.75f, 74.25f,
        75.25f, 76.25f, 77.25f, 78.25f, 80.25f, 80.75f, 81.75f, 82.25f,
        84.25f, 85.25f, 86.75f, 87.75f, 90.25f, 91.25f, 93.25f, 94.25f,
        95.25f, 95.75f, 96.75f, 97.75f, 98.75f, 99.25f, 99.75f, 100.50f,
        100.75f, 101.25f, 101.75f, 102.25f, 103.25f, 103.75f, 104.75f,
        105.25f, 105.75f, 106.25f, 106.75f, 107.75f, 108.75f,
        109.25f, 109.75f, 110.25f, 111.25f, 111.75f, 112.75f,
        113.75f, 114.25f, 115.25f, 115.75f, 116.25f, 116.75f,
        117.75f, 118.75f, 119.25f, 119.75f, 120.25f, 120.75f,
        121.75f, 122.75f, 123.25f, 123.75f, 124.25f, 126.25f, 128.25f,
        128.75f, 129.25f, 130.25f, 130.75f, 132.75f, 134.75f, 135.25f,
        136.25f, 137.25f, 139.25f, 140.25f, 141.75f, 142.25f, 144.25f,
        148.25f, 152.25f, 154.25f, 156.25f, 160.25f, 162.25f, 164.25f, 168.25f, 170.25f, 172.25f,
        176f};

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

        if(!GetComponent<AudioSource>().isPlaying)
        {
            sc.changeScene(2);
        }
    }
}
