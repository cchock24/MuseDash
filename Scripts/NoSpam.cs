using System;
using System.Collections.Generic;
using UnityEngine;

public class NoSpam : MonoBehaviour
{
     public Note_Object leadNote;
     public List<GameObject> list = new List<GameObject>();
     public bool start = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update(){
        if(!(leadNote == null)){
            if(Input.GetKeyDown(leadNote.downKey) || Input.GetKeyDown(leadNote.leftKey)){
                if(!leadNote.canBePressed){
                    Debug.Log("No Note");
                    Song_Manager.instance.NoteMiss();
                }
            }
        }
       
    }

    public void RegisterNote(GameObject note)
    {
        list.Add(note);
    }
    
    public void AssignLeadNote(){
        if(start){
            if(!(list == null)){
                leadNote = list[0].GetComponent<Note_Object>();
                Debug.Log(list[0]);
            }
        } 
    }
    public void deleteLead(){
        if(!(list == null)){
            list.RemoveAt(0);
        }
    }
}
