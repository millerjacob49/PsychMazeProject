using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownTrials : MonoBehaviour
{

    public int trialAmounts = 1;

   

    public void HandleInput(int val)
    {
        trialAmounts= val + 1;
        Debug.Log(val);
        Debug.Log(trialAmounts);
    }

    
}
