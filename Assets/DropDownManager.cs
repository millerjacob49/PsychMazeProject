using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownManager : MonoBehaviour
{

    public GameObject MiniMap;
    public GameObject FullMap;
    public TMPro.TMP_Dropdown DropVal;
    public int MapValue;


    // Start is called before the first frame update
    public void DDInput(int val)
    {
        MapValue = val;
        RemoveMaps();
        if (val == 1)
        {
            MiniMap.SetActive(true);
        }
        if (val == 2)
        {
            FullMap.SetActive(true);
        }
    }

    public void ReplaceMaps()
    {
        if (MapValue == 1)
        {
            MiniMap.SetActive(true);
        }
        if (MapValue == 2)
        {
            FullMap.SetActive(true);
        }
    }

    public void RemoveMaps()
    {
        if (MiniMap!=null)
        {
            MiniMap.SetActive(false);
        }
        if (FullMap!=null)
        {
            FullMap.SetActive(false);
        }
    }
}
