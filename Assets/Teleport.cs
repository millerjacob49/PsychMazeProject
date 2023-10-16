using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using System;
using System.Threading;
using TMPro;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportTarget;
    public GameObject Player;
    public GameObject TimeOutText;
    public GameObject Menu;


    public void Reposition()
    {
        //Menu.SetActive(true);
            Debug.Log("Repo called!");
        TimeOutText.SetActive(true);
        //Thread.Sleep(2500);
        transform.position = teleportTarget.position;
        Physics.autoSyncTransforms = true;
        Thread.Sleep(2500);
        //TimeOutText.SetActive(false);
        Debug.Log("Repo Ended!");
        
    }
}

