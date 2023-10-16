using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;

public class GetText : MonoBehaviour
{
    public TextMeshProUGUI textElementInstructions;
    public TextMeshProUGUI textElementDebrief;
    public TextAsset TextInstructions;
    public TextAsset Debrief;
    public TextMeshProUGUI textElementTimeOutDisplay;
    public TextAsset TimeOutDisplay;

    void Start()
    {
        textElementInstructions.text = File.ReadAllText(Application.streamingAssetsPath + "/Input/Instructions.txt");
        textElementDebrief.text = File.ReadAllText(Application.streamingAssetsPath + "/Input/Debrief.txt");
        textElementTimeOutDisplay.text = File.ReadAllText(Application.streamingAssetsPath + "/Input/TimeOutDisplay.txt");
    }
}
