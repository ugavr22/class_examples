using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebugText : MonoBehaviour
{
    public TMP_Text text;
    public static DebugText debugText;
    public static void Log(string message)
	{
        if(debugText == null)
		{
            debugText = GameObject.Find("DebugText").GetComponent<DebugText>();
		}
        debugText.text.text = message;
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
