using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Experiment;
using TMPro;


public class TrialCounterDisplay : MonoBehaviour
{
    
    public string DisplayText;
    public int curTrial;
    public string TrialType;
    public GameObject Manager;
    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        DisplayText = "Trial 1: Practice Run";
        textElement.text = DisplayText;
    }

    // Update is called once per frame
    void Update()
    {
        GetTrialInfo();
        textElement.text = "Trial " + (curTrial+1) + TrialType;
    }

    void GetTrialInfo()
    {
        TrialManager TrialMgmt = Manager.GetComponent<TrialManager>();
        if (TrialMgmt.TrialCompletion == 0)
        {
            TrialType = ": Practice Run";
        }
        else if(TrialMgmt.TrialCompletion == 1)
        {
            TrialType = ": Actual Run";
        }

        SessionManager SessionMgmt = Manager.GetComponent<SessionManager>();
        curTrial = SessionMgmt.currentTrial;
    }
}
