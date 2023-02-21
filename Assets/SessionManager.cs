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
    string SubjectInputID;
    public int currentTrial = 1;
    public string sessionName = " ";
    public int trialAmounts;    //retrieved from text fule
    public int miniMapSet;      //retrieved from settings menu
    public int trialCompletion;  //retrieved from trial manager
    


    // Start is called before the first frame update
    public void Start()
    {
        string trialInputText = File.ReadAllText(Application.streamingAssetsPath + "/Input/TrialNumberInput.txt");
        trialAmounts = int.Parse(trialInputText);
        


    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetCompletion() == 2)
        {
            currentTrial++;
            TrialManager trialMgmt = GetComponent<TrialManager>();
            trialMgmt.NewTrial();

        }

        if ((currentTrial+1) > trialAmounts)
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


        DropDownManager DDMaps = DDMapMgmt.GetComponent<DropDownManager>();
        miniMapSet = DDMaps.MapValue;
        File.AppendAllText(sessionName, "Header \n" + ", Condition: ," + MiniMapConvert(miniMapSet) + "\n" + ",SubjectNumber: " + SubjectInputID + "\n" + ",Time Started: " + System.DateTime.Now.ToString("MM-dd_HH-mm-ss") + "\n");
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
            SubjectInputID = subjectID;
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
