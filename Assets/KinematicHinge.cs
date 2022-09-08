using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicHinge : MonoBehaviour
{
    public Vector3 localAxis;
    public float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(localAxis, angularVelocity * Time.deltaTime, Space.Self);
    }
}
