using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRHand : MonoBehaviour
{
    public InputAction trigger;
    public OVRInput.Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller));
        //trigger.performed += (ctx) => {
        //    Debug.Log(ctx.ReadValue<float>());
        //};
        //trigger.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
