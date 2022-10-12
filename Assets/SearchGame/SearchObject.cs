using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SearchObject : MonoBehaviour
{
    public string label;
    public TMP_Text label3D;
    // Start is called before the first frame update
    void Start()
    {
        label3D.text = label;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
