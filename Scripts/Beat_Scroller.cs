// Inspired by GamesPlusJames Youtube
using UnityEngine;

public class Beat_Scroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public float beatSpeed;
    public float actualSpeed;
    private Vector3 currentPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualSpeed = beatTempo / beatSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // When the Game starts moves the notes across the screen
        if(hasStarted){
            transform.position -= new Vector3(actualSpeed* Time.deltaTime, 0f, 0f);
            currentPosition = transform.position;
        }
    }


}
