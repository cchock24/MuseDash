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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        GameObject duplicate = Instantiate(topEnemy, vectorTop, Quaternion.identity);
        duplicate.SetActive(true);
        // Access the original and the clone's Enemy components
        Beat_Scroller originalEnemy = topEnemy.GetComponent<Beat_Scroller>();
        Beat_Scroller duplicateEnemy = duplicate.GetComponent<Beat_Scroller>();

        // Explicitly copy variables from the original to the duplicate
        duplicateEnemy.beatSpeed = originalEnemy.beatSpeed;
        duplicateEnemy.beatTempo = originalEnemy.beatTempo;
    }
    public void DuplicateBot()
    {
        GameObject duplicate = Instantiate(botEnemy, vectorBot, Quaternion.identity);
         duplicate.SetActive(true);
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
            // Spawn the note at the appropriate position (for simplicity, at (0, 0, 0))
            DuplicateTop();
        }
    }

    public IEnumerator Test()
    {
        foreach (float noteTime in testTime)
        {
            // Wait for the specified time before spawning a note
            yield return new WaitForSeconds(noteTime);
            // Spawn the note at the appropriate position (for simplicity, at (0, 0, 0))
            DuplicateTop();
        }
    }

    public IEnumerator SpawnBotNotes()
    {
        foreach (float noteTime in botTimes)
        {
            // Wait for the specified time before spawning a note
            yield return new WaitForSeconds(noteTime);
            // Spawn the note at the appropriate position (for simplicity, at (0, 0, 0))
            DuplicateBot();
        }
    }

    void LoadNoteTimes()
    {
        // Eventually Add Code here that Changes offset based on Speed Settings
        offset = 1.58f;
        string[] lines = TopnoteTimesFile.text.Split('\n');

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
