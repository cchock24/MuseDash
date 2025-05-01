using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Beat_Scroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public float beatSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatTempo = beatTempo / beatSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            if(Input.anyKey)
            {
                hasStarted = true;
            }
        }
        else{
            transform.position -= new Vector3(beatTempo* Time.deltaTime, 0f, 0f);
        }
    }
}
