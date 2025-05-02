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
     if(Input.GetKeyDown(leftKey)){
        if(canBePressed){
            gameObject.SetActive(false);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
     }   
     if(Input.GetKeyDown(downKey)){
        if(canBePressed){
            gameObject.SetActive(false);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
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

}
