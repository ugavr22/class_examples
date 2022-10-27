using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGaze : MonoBehaviour
{

    [SerializeField] Transform eyeCenter;
    [SerializeField] Transform eyeDirection; //must be a child (or child's child) relative to eye Center
    public Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        

        //targetRotation* eyeDirection.localRotation.inverse() = eyeCenter_rotation*eyeDirection.localRotation*eyeDirection.localRotation.inverse()
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion prevRotation = eyeDirection.localRotation;
        eyeDirection.LookAt(lookAtTarget);
        Quaternion targetRotation = eyeDirection.rotation; //where we want to achieve
        eyeDirection.localRotation = prevRotation;

        eyeCenter.rotation = targetRotation * Quaternion.Inverse(eyeDirection.localRotation);


    }
}
