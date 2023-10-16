using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experiment;
using System;
using System.Threading;
using System.IO;


public class MazeTrigger : MonoBehaviour
{
    public string filename = Application.streamingAssetsPath + "/Input/TimeOut.txt";
    public float StartTime = 0.0f;
    public float CurTime = 0.0f;
    public GameObject TrialManager1;
    public GameObject StartPosition;
    public int Go = 0;
    public float DefaultTime = 150.0f;

    public void Start()
    {

        if (File.Exists(filename))
        {
            string text = File.ReadAllText(filename);
            if (float.TryParse(text, out float value))
            {
                DefaultTime = value;
                Debug.Log("SetTime: " + DefaultTime);
            }
        }
        
    }


    public void OnTriggerEnter()
    {
        Debug.Log("TimeOUT:" + DefaultTime);
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

        if(CurTime > DefaultTime && Go == 1)
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
