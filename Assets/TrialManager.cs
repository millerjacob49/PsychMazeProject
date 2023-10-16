using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Experiment
{

    public class TrialManager : MonoBehaviour
    {

        public GameObject StartPosition;
        public GameObject TimerActiveZone;
        public GameObject CloseMazePlane;
        public GameObject MapControls;
        public GameObject TimeOutText;
        public bool Triggered = false;
        public float TotalTime;
        public float StartTimePractice = 0f;
        public float EndTimePractice = 0f;
        public float StartTime = 0f;
        public float EndTime = 0f;
        public float curTime;
        public int curTrial;    //Want to get this from the SessionManager script
        public int TrialCompletion;



        public void StartTimer()
        {

            //Place a plane to block player into the maze
            CloseMazePlane.SetActive(true);

            if (StartTimePractice == 0)
            {

                StartTimePractice = Time.time;

               
            }
            else
            {
                StartTime = Time.time;
            }

        }

        

        public void EndTimer()
        {
            Debug.Log("End Timer Called");

            if (EndTimePractice == 0)
            {
                //Debug.Log("ENDTIMER CALLED");
                EndTimePractice = Time.time;
                WriteDataToFilePractice();
                TrialCompletion = 1;

                TimeOutText.SetActive(true);
                Debug.Log("Is this called twice??");
                DropDownManager MapMgmt = MapControls.GetComponent<DropDownManager>();
                MapMgmt.RemoveMaps();   //remove map for actual run
                
            }
            else
            {
                //Debug.Log("ENDTIMER ELSE IS BEING CALLED");
                EndTime = Time.time;
                WriteDataToFileExp();   //remove Exp to revert to original method
                TrialCompletion = 2;
                

            }

            CloseMazePlane.SetActive(false);
            Teleport teleport = StartPosition.GetComponent<Teleport>();
            teleport.Reposition();
            TimeOutText.SetActive(false);

        }
/*
        public void WriteDataToFile()
        {
            SessionManager sessionManager = GetComponent<SessionManager>();
            curTrial = sessionManager.currentTrial;
            float TotalTimePractice = EndTimePractice - StartTimePractice;
            float TotalTime = EndTime - StartTime;
            string Data = (curTrial+1) + ", Practice, " + TotalTimePractice + "\n" + (curTrial+1) + ", Actual, " + TotalTime + "\n";
            string FileName = sessionManager.sessionName;
            File.AppendAllText(FileName, Data);
        }
*/

        public void WriteDataToFilePractice()
        {
            SessionManager sessionManager = GetComponent<SessionManager>();
            curTrial = sessionManager.currentTrial;
            float TotalTimePractice = EndTimePractice - StartTimePractice;
            string Data = (curTrial + 1) + ", Practice, " + TotalTimePractice;
            string FileName = sessionManager.sessionName;
            File.AppendAllText(FileName, Data);
        }

        public void WriteDataToFileExp()
        {
            SessionManager sessionManager = GetComponent<SessionManager>();
            curTrial = sessionManager.currentTrial;
            float TotalTime = EndTime - StartTime;
            string Data = "\n" + (curTrial + 1) + ", Actual, " + TotalTime + "\n";
            string FileName = sessionManager.sessionName;
            File.AppendAllText(FileName, Data);
        }

        public void NewTrial()
        {
            //Reset everything (dont delete files/data)
            TrialCompletion = 0;
            StartTime = 0;
            StartTimePractice= 0;
            EndTime = 0;
            EndTimePractice= 0;

            //replace map for practice run
            DropDownManager MapMgmt = MapControls.GetComponent<DropDownManager>();
            MapMgmt.ReplaceMaps();


        }
    }

}