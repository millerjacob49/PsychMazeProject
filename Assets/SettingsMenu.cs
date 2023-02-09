using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* still need :
 * Toggle minimap
 * Read/Display instructions from text file
 * */


public class SettingsMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject StartButton;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

        //Disables player and displays menu
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Menu.SetActive(true);
        Player.SetActive(false);  
    }

    //on finalize settings, set camera to face forward at origin.

    void onClick()
    {
        StartMaze();
    }

    //exits menu and re-enables player
    public void StartMaze()
    {

        Player.SetActive(true);
        Cursor.visible = false;

        Menu.SetActive(false);
        
        
    }



    
    

    
}
