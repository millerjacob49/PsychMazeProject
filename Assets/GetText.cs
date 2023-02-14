using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;

public class GetText : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public TextAsset TextIn;

    void Start()
    {
        //textElement.text = Path.Combine(Application.streamingAssetsPath, "/Input/Instructions.txt");
        textElement.text = File.ReadAllText(Application.streamingAssetsPath + "/Input/Instructions.txt");
        //textElement.text = TextIn.ToString();
    }
}
