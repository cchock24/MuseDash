using TMPro;
using UnityEngine;

public class Song_Manager : MonoBehaviour
{
    public AudioSource song;
    public bool startPlaying;
    public Beat_Scroller BS_Ground;
    public Beat_Scroller BS_Fly;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying){
            if(Input.anyKeyDown){
                startPlaying = true;
                BS_Ground.hasStarted = true;
                BS_Fly.hasStarted = true;
                song.Play();
            }
        }
    }
}
