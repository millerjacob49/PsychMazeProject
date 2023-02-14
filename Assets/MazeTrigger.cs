using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experiment;


public class MazeTrigger : MonoBehaviour
{

    public GameObject TrialManager1;



    public void OnTriggerEnter()
    {
        TrialManager trialMgmt = TrialManager1.GetComponent<TrialManager>();
        trialMgmt.StartTimer();
    }

    public void OnTriggerExit()
    {
        TrialManager trialMgmt = TrialManager1.GetComponent<TrialManager>();
        trialMgmt.EndTimer();
    }
}
