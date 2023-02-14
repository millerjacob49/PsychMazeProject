using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Experiment;



public class SessionManager : MonoBehaviour

    
{
    public GameObject DDTrialMgmt;
    public GameObject DDMapMgmt;
    public GameObject Player;
    public GameObject EndText;
    public int currentTrial = 0;
    public string sessionName = " ";
    public int trialAmounts;    //retrieved from settings menu
    public int miniMapSet;      //retrieved from settings menu
    public int trialCompletion;  //retrieved from trial manager
    


    // Start is called before the first frame update
    public void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        trialAmounts = 1; //initializing to 2 just to make sure game doesnt freeze at start
        
        if (GetCompletion() == 2)
        {
            currentTrial++;
            TrialManager trialMgmt = GetComponent<TrialManager>();
            trialMgmt.NewTrial();

            DropDownTrials DDTrials = DDTrialMgmt.GetComponent<DropDownTrials>();
            trialAmounts = DDTrials.trialAmounts;
        }

        if (currentTrial > trialAmounts)
        {
            Debug.Log(currentTrial + ">" + trialAmounts + "So End");
            //End of the program... Figure out what to do here.
            //Make sure all data is written, disable player
            EndSession();
        }
    }

    public int GetCompletion()
    {
        TrialManager trialManager = GetComponent<TrialManager>();
        return trialManager.TrialCompletion;

        
    }

    public void Finalizer()
    {

        DropDownTrials DDTrials = DDTrialMgmt.GetComponent<DropDownTrials>();
        trialAmounts = DDTrials.trialAmounts;

        DropDownManager DDMaps = DDMapMgmt.GetComponent<DropDownManager>();
        miniMapSet = DDMaps.MapValue;
        File.AppendAllText(sessionName, "Header \n" + ", Condition: ," + MiniMapConvert(miniMapSet) + "\n" + ",SubjectNumber: " + /*JUST AN EXAMPLE*/ "117" + "\n" + ",Time Started: " + System.DateTime.Now.ToString("MM-dd_HH-mm-ss") + "\n");
        File.AppendAllText(sessionName, "***** \n");

        string settingsData = "Trial, P/A, Time" + "\n";
        
        File.AppendAllText(sessionName, settingsData);

    }

    public bool CheckFile(string subjectID)
    {
        DropDownManager DDMaps = DDMapMgmt.GetComponent<DropDownManager>();
        miniMapSet = DDMaps.MapValue;

        sessionName = subjectID + "." + MiniMapConvert(miniMapSet) + ".csv";

        if (File.Exists(sessionName))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void CreateLogFile(string subjectID)
    {
        SettingsMenu settings = GetComponent<SettingsMenu>();
        TrialManager trialManager = GetComponent<TrialManager>();
        sessionName = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); //This will be named by subject ID instead
        //sessionName = Application.persistentDataPath + sessionName + ".csv";    //Can I find a better place to write to?
        sessionName = "../PsychMaze Project/Assets/AuxFiles/Output/" + sessionName + ".csv";
    }


    string MiniMapConvert (int val)
    {
        if(miniMapSet == 0)
        {
            return "NoMap";
        }
        else if(miniMapSet == 1)
        {
            return "MiniMap";
        }
        else
        {
            return "FullMap";
        }
    }

    void EndSession()
    {
        Player.SetActive(false);
        EndText.SetActive(true);
    }
}
