using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map_Track : MonoBehaviour
{
   private float timer = 0f;
    private bool timerStarted = false;
    public float timerDuration = 5f;
    public List<float> topTime = new List<float>();
    public List<float> botTime = new List<float>();

    public string filePathTop;
        public string filePathBot;

    void Start()
    {
        filePathTop = Application.dataPath + "/Top_Map.txt";  // Define the file path (in this case, in the project's "Assets" folder)
        filePathBot = Application.dataPath + "/Bot_Map.txt";
    }
    void Update()
    {
        // Start timer when the player presses the space bar
        if (Input.GetKeyDown(KeyCode.Space) && !timerStarted)
        {
            timerStarted = true;
            Debug.Log("Timer Started!");
        }

        if (timerStarted)
        {
            timer += Time.deltaTime;

           if(Input.GetKeyDown(KeyCode.LeftArrow)){
                topTime.Add(timer);
           }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                botTime.Add(timer);
           }
        }

        if(Input.GetKeyDown(KeyCode.F)){
             WriteArrayToFile(filePathTop, topTime);
             WriteArrayToFile(filePathBot, botTime);
        }
    }

     void WriteArrayToFile(string path, List<float> list)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                // Loop through the float array and write each value to the file
                foreach (float value in list)
                {
                    writer.WriteLine(value);  // Write each float value on a new line
                }
            }

            Debug.Log("Array values written to file successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error writing to file: " + e.Message);
        }
    }
}


