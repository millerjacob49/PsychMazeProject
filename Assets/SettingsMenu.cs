using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Experiment;


public class SettingsMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject StartButton;
    public GameObject MapDD;
    public GameObject Player;
    public GameObject Manager;
    public GameObject InstText;
    public GameObject SubjectText;
    public string SubjectInput;



    // Start is called before the first frame update
    void Start()
    {

        //Disables player and displays menu
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Menu.SetActive(true);
        Player.SetActive(false);  
    }

    void onClick()
    {
        StartMaze();
    }

    //exits menu and re-enables player
    public void StartMaze()
    {
        SessionManager sessionManager1 = Manager.GetComponent<SessionManager>();

        //Check that the integer entered in the input box has not been used yet *************************************
        SubjectInput = SubjectText.GetComponent<TMP_InputField>().text;
        
        if (!sessionManager1.CheckFile(SubjectInput))
        {
            Player.SetActive(true);
            Cursor.visible = false;


            sessionManager1.Finalizer();

            RemoveMenu();
        }
        
    }

    public void RemoveMenu()
    {
        Menu.SetActive(false);
        StartButton.SetActive(false);
        MapDD.SetActive(false);
        InstText.SetActive(false);
        SubjectText.SetActive(false);
    }

    



    
    

    
}
