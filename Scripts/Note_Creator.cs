using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
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
        Debug.Log(duplicateEnemy.beatTempo);
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
        Debug.Log(duplicateEnemy.beatTempo);
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
            Debug.Log("Note spawned at: " + noteTime);
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
            Debug.Log("Note spawned at: " + noteTime);
        }
    }

    void LoadNoteTimes()
    {
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
    }

     public IEnumerator TestNotes()
    {
        foreach (float noteTime in testTime)
        {
            // Wait for the specified time before spawning a note
            yield return new WaitForSeconds(noteTime);

            // Spawn the note at the appropriate position (for simplicity, at (0, 0, 0))
            DuplicateBot();
            Debug.Log("Note spawned at: " + noteTime);
        }
    }
}
