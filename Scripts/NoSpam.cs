using System;
using System.Collections.Generic;
using UnityEngine;

public class NoSpam : MonoBehaviour
{
     public Note_Object leadNotetop;
     public Note_Object leadNotebot;
     public List<GameObject> top = new List<GameObject>();
     public List<GameObject> bot = new List<GameObject>();
     public bool start = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update(){  
        // First Checks to Make sure note is not null
        if(!(leadNotetop == null)){
            // If note is pressed and there is no note count as miss
            if(Input.GetKeyDown(leadNotetop.downKey) || Input.GetKeyDown(leadNotetop.leftKey)){
                if(!leadNotetop.canBePressed){
                    Song_Manager.instance.NoteMiss();
                }
            }
        }
        if(!(leadNotebot == null)){
            if(Input.GetKeyDown(leadNotebot.downKey) || Input.GetKeyDown(leadNotebot.leftKey)){
                if(!leadNotebot.canBePressed){
                    Song_Manager.instance.NoteMiss();
                }
            }
        }
        // If there is a press and there is no note on screen count as miss
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
            if(leadNotebot == null){
                Song_Manager.instance.NoteMiss();
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)){
            if(leadNotetop == null){

                Song_Manager.instance.NoteMiss();
            }
        }
    }

    // Add Notes to list of notes
    public void RegisterNoteTop(GameObject note)
    {
        top.Add(note);
    }
    public void RegisterNoteBot(GameObject note)
    {
        bot.Add(note);
    }    
    // Assign lead note as lead note
    public void AssignLeadNoteTop(){
        if(start){
            if(top.Count > 0){
                leadNotetop = top[0].GetComponent<Note_Object>();
            }
        } 
    }
    public void AssignLeadNoteBot(){
        if(start){
            if(bot.Count > 0){
                leadNotebot = bot[0].GetComponent<Note_Object>();
            }
        } 
    }
    // Remove the lead note
    public void deleteLeadTop(){
        if(top.Count > 0){
            top.RemoveAt(0);
        }
    }
    public void deleteLeadBot(){
        if(bot.Count > 0){
            bot.RemoveAt(0);
        }
    }
}
