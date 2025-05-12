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


    private void HandleNotePress(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (canBePressed)
            {
                Destroy(gameObject); // Destroy the note
                GameObject effect = Instantiate(onCollectEffect, transform.position, transform.rotation); // Instantiate effect
                Destroy(effect, 2f); // Destroy effect after 2 seconds
                Song_Manager.instance.NoteHit();
                check.deleteLead();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator"){
            canBePressed = true;
        }
    }

private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator"){
            canBePressed = false;
        }
    }
private void exitScreen(){
    if(gameObject.transform.position.x <= -7.76){
        Destroy(gameObject);
        check.deleteLead();
        Song_Manager.instance.NoteMiss();
    }
}

public void start(){
    started = true;
}
}
