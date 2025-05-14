// Inspired by GamesPlusJames Youtube
using UnityEngine;

public class Note_Object : MonoBehaviour
{
    public GameObject onCollectEffect;
    public Note_Object partner;
    public bool canBePressed;
    public KeyCode downKey;
    public KeyCode leftKey;

    public NoSpam check;
    public bool started = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        exitScreen();
        HandleNotePress(leftKey);   
        HandleNotePress(downKey);
    }

    // When Hit Key is pressed check if its a hit
    private void HandleNotePress(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (canBePressed)
            {
                if(key == KeyCode.LeftArrow || key == KeyCode.DownArrow){
                    check.deleteLeadBot();
                    check.AssignLeadNoteBot();

                }
                else{
                    check.deleteLeadTop();
                    check.AssignLeadNoteTop();
                }
                // If Hit destroy note add particle effect
                Destroy(gameObject); // Destroy the note
                GameObject effect = Instantiate(onCollectEffect, transform.position, transform.rotation); // Instantiate effect
                Destroy(effect, 2f); // Destroy effect after 2 seconds
                Song_Manager.instance.NoteHit();
            }
        }
    }
    // When Note enters trigger/circle zone makes it possible to "hit"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator"){
            canBePressed = true;
        }
    }
    // When notes leaves unallow "hit"
    private void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "Activator"){
                canBePressed = false;
            }
        }
    // When note leaves screen destroy and count as miss
    private void exitScreen(){
        if(gameObject.transform.position.x <= -7.76){
            if(gameObject.transform.position.y > 0){
                check.deleteLeadTop();
                check.AssignLeadNoteTop();
            }
            else{
                check.deleteLeadBot();
                check.AssignLeadNoteBot();
            }
            Destroy(gameObject);
            Song_Manager.instance.NoteMiss();
        }
    }
    // Allow this code to run
    public void start(){
        started = true;
    }
}
