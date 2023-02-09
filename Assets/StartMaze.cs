using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMaze : MonoBehaviour
{

    public GameObject StartTimerPlane;
    public GameObject EndTimerPlane;
    public bool Triggered = false;
    public double Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //show instructions & settings
        
    }

    //50Hz
    void FixedUpdate()
    {
        if (Triggered)
        {
            Timer += 0.02;
        }
        
    }

    private void OnTriggerEnter()
    {
        //StartTimerPlane.SetActive(false);

        if (Triggered == false)
        {
            Triggered = true;
        }
        else if (Triggered == true)
        {
            Triggered = false;
        }
        
    }

    
}
