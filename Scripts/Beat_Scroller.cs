using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Beat_Scroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public float beatSpeed;
    public float actualSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualSpeed = beatTempo / beatSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted){
            transform.position -= new Vector3(actualSpeed* Time.deltaTime, 0f, 0f);
        }
    }


}
