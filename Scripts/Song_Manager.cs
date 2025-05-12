using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.IO;

public class Song_Manager : MonoBehaviour
{
    public AudioSource song;
    public bool startPlaying;
    public Beat_Scroller BS_Ground;
    public Beat_Scroller BS_Fly;
    public static Song_Manager instance;
    public static int combo = 0;
    public static int notesHit = 0;
    public static int notesMissed = 0;
    public TextMeshProUGUI comboText;
    public Note_Object topEnemy;
    public Note_Object botEnemy;

    public Note_Creator creator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        song.clip = Resources.Load<AudioClip>(StaticData.song);
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
                topEnemy.gameObject.SetActive(false);
                botEnemy.gameObject.SetActive(false);
                topEnemy.start();
                botEnemy.start();
                //StartCoroutine(creator.Test());
                StartCoroutine(creator.SpawnTopNotes());
                StartCoroutine(creator.SpawnBotNotes());
            }
        }
        /*
        if (!song.isPlaying && startPlaying)
        {
            Debug.Log("Music has ended!");
            SceneManager.LoadScene("EndScreen");
        }
        */
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
