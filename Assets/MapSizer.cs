using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapSizer : MonoBehaviour
{
    public string filename = Application.streamingAssetsPath + "/Input/MapSize.txt";
    public float defaultHeight = 3000f;

    // Start is called before the first frame update
    void Start()
    {
        float height = defaultHeight;

        if (File.Exists(filename))
        {
            string text = File.ReadAllText(filename);
            if (float.TryParse(text, out float value))
            {
                height = value;
            }
        }

        Vector3 pos = transform.position;
        pos.y = height;
        transform.position = pos;

    }

    void Update()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = 0;
        eulerAngles.z = 0;
        transform.eulerAngles = eulerAngles;
    }


}
