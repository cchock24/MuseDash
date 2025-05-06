using UnityEngine;

public class Note_Object : MonoBehaviour
{
    public GameObject onCollectEffect;
    public bool canBePressed;
    public KeyCode downKey;
    public KeyCode leftKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exitScreen();
        
        if(!canBePressed){
            if(Input.anyKeyDown){
                Debug.Log("No Note");
            }
        }
     if(Input.GetKeyDown(leftKey)){
        if(canBePressed){
            gameObject.SetActive(false);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
            Song_Manager.instance.NoteHit();
        }
     }   
     if(Input.GetKeyDown(downKey)){
        if(canBePressed){
            gameObject.SetActive(false);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
            Song_Manager.instance.NoteHit();
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
            Song_Manager.instance.NoteMiss();
        }
    }
private void exitScreen(){
    if(gameObject.transform.position.x <= -7.76){
        gameObject.SetActive(false);
        Debug.Log("off screen");
    }
}
}
