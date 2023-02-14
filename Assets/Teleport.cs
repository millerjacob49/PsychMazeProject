using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using System;
using System.Threading;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportTarget;
    public GameObject Player;
    public GameObject NewText;
    

    public void Reposition()
    {
        
        NewText.SetActive(true);
        //Thread.Sleep(2500);
            //Display something saying reloading??
        transform.position = teleportTarget.position;
        Physics.autoSyncTransforms = true;
        Thread.Sleep(2500);
        NewText.SetActive(false);
        
    }
}

