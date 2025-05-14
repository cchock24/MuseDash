using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using System;

public class Note_Creator : MonoBehaviour
{
    public GameObject topEnemy;
    public GameObject botEnemy;
    public KeyCode d;
    public Vector2 vectorTop = new Vector2 (7.76f,3f);
    public Vector2 vectorBot = new Vector2 (7.76f,-2.46f);
    public List<float> botTimes = new List<float>();
    public List<float> topTimes = new List<float>();
    public float[] testTime = new float[3] {1f,3f,5f};
    public TextAsset TopnoteTimesFile;
    public TextAsset BotnoteTimesFile;
    public float offset;
    public NoSpam check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TopnoteTimesFile = Resources.Load<TextAsset>(StaticData.upMap);
        BotnoteTimesFile = Resources.Load<TextAsset>(StaticData.downMap);
        LoadNoteTimes();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(d)){
            DuplicateBot();
            DuplicateTop();
        }
    }

    public void DuplicateTop()
    {
        // Duplicate Original Note. Makes sure to set the Note Speed correctly
        // When Note is created add it to NoSpam list and reassign leading note
        check.start = true;
        GameObject duplicate = Instantiate(topEnemy, vectorTop, Quaternion.identity);
        duplicate.SetActive(true);
        check.RegisterNoteTop(duplicate);
        check.AssignLeadNoteTop();
        // Access the original and the clone's Enemy components
        Beat_Scroller originalEnemy = topEnemy.GetComponent<Beat_Scroller>();
        Beat_Scroller duplicateEnemy = duplicate.GetComponent<Beat_Scroller>();

        // Explicitly copy variables from the original to the duplicate
        duplicateEnemy.beatSpeed = originalEnemy.beatSpeed;
        duplicateEnemy.beatTempo = originalEnemy.beatTempo;
    }
    public void DuplicateBot()
    {
        check.start = true;
        GameObject duplicate = Instantiate(botEnemy, vectorBot, Quaternion.identity);
         duplicate.SetActive(true);
         check.RegisterNoteBot(duplicate);
         check.AssignLeadNoteBot();
        // Access the original and the clone's Enemy components
        Beat_Scroller originalEnemy = botEnemy.GetComponent<Beat_Scroller>();
        Beat_Scroller duplicateEnemy = duplicate.GetComponent<Beat_Scroller>();

        // Explicitly copy variables from the original to the duplicate
        duplicateEnemy.beatSpeed = originalEnemy.beatSpeed;
        duplicateEnemy.beatTempo = originalEnemy.beatTempo;
    }

     // Coroutine to spawn notes at specified times
    public IEnumerator SpawnTopNotes()
    {
        foreach (float noteTime in topTimes)
        {
            // Wait for the specified time before spawning a note
            yield return new WaitForSeconds(noteTime);
            DuplicateTop();
        }
    }
    // Used for a Test Array of Notes
    public IEnumerator Test()
    {
        foreach (float noteTime in testTime)
        {
            // Wait for the specified time before spawning a note
            yield return new WaitForSeconds(noteTime);
            DuplicateTop();
        }
    }

    public IEnumerator SpawnBotNotes()
    {
        foreach (float noteTime in botTimes)
        {
            // Wait for the specified time before spawning a note
            yield return new WaitForSeconds(noteTime);
            DuplicateBot();
        }
    }

    void LoadNoteTimes()
    {
        // Offset (time needed to travel from spawn location to hit location)
        offset = 1.58f;
        // Makes a string array of each line of the txt
        string[] lines = TopnoteTimesFile.text.Split('\n');

        // For Each string get int value add it to List
        foreach (string line in lines)
        {
            if (float.TryParse(line.Trim(), out float time))
            {
                topTimes.Add(time);
            }
        }

        lines = BotnoteTimesFile.text.Split('\n');

        foreach (string line in lines)
        {
        if (float.TryParse(line.Trim(), out float time))
            {
                botTimes.Add(time);
            }
        }

        // Change Times to Fit
        float temp = topTimes[1] - offset;
        for(int i = 0; i < topTimes.Count; i++){
            topTimes[i] -= offset;
            if(i == 1){
                topTimes[i] = topTimes[i] - topTimes[i-1];
            }
            if(i > 1){
                float save = topTimes[i];
                topTimes[i] = topTimes[i] - temp;
                temp = save;
            }
        }
        temp = botTimes[1] - offset;
        for(int i = 0; i < botTimes.Count; i++){
            botTimes[i] -= offset;
            if(i == 1){
                botTimes[i] = botTimes[i] - botTimes[i-1];
            }
            if(i > 1){
                float save = botTimes[i];
                botTimes[i] = botTimes[i] - temp;
                temp = save;
            }
        }
        Debug.Log("Complete Change");
    }
}


