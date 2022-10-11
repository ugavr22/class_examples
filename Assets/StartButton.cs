using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StartButton : MonoBehaviour
{
    public UnityAction<VRHand> buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        VRHand hand = rb.GetComponent<VRHand>();
        if (hand == null) return;

        buttonPressed(hand);
	}
}
