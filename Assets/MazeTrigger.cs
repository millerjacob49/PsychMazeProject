using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experiment;
using System;
using System.Threading;


public class MazeTrigger : MonoBehaviour
{
    public float StartTime = 0.0f;
    public float CurTime = 0.0f;
    public GameObject TrialManager1;
    public GameObject StartPosition;
    public int Go = 0;



    public void OnTriggerEnter()
    {
        Debug.Log("OntriggerEneter called");
        TrialManager trialMgmt = TrialManager1.GetComponent<TrialManager>();
        trialMgmt.StartTimer();
        StartTime = Time.time;
        Go = 1;

    }

    public void Update()
    {
        CurTime = Time.time - StartTime;
        Debug.Log(CurTime + ", " + StartTime + ", " + Go);

        if(CurTime > 2.0f && Go == 1)
        {
            Go = 0;
            StartTime = 0.0f;
            CurTime = 0.0f;
            Teleport teleport = StartPosition.GetComponent<Teleport>();     //This is bad practice...but the way its gonna be done for now
            teleport.Reposition();
        }
        
    }

    public void OnTriggerExit()
    {
        Debug.Log("OnTriggerExit is called. (Should only be once.");
        Go = 0;
        TrialManager trialMgmt = TrialManager1.GetComponent<TrialManager>();
        trialMgmt.EndTimer();
    }
}
