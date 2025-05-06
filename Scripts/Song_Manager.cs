using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Song_Manager : MonoBehaviour
{
    public AudioSource song;
    public bool startPlaying;
    public Beat_Scroller BS_Ground;
    public Beat_Scroller BS_Fly;
    public static Song_Manager instance;
    public int combo = 0;
    public int notesHit = 0;
    public int notesMissed = 0;
    public TextMeshProUGUI comboText;

    public Note_Creator creator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        comboText.text = "Combo: " + 0;
        song.Stop();
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
                StartCoroutine(creator.TestNotes());
                StartCoroutine(creator.SpawnTopNotes());
                StartCoroutine(creator.SpawnBotNotes());
            }
        }
    }

    public void NoteHit(){
        Debug.Log("Note Hit");
        combo++;
        notesHit++;
        comboText.text = "Combo: " + combo;
    }
    public void NoteMiss(){
        Debug.Log("Note Miss");
        combo = 0;
        notesMissed++;
    }
}
