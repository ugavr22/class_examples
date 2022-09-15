using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointEvent : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HingeJoint joint = GetComponent<HingeJoint>();
        //Debug.Log(joint.angle);
    }
}
