using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocation : MonoBehaviour
{
    public SearchObject target;
    public bool isFound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        SearchObject so = rb.GetComponent<SearchObject>();
        if (so == null) return;
        isFound = so == target;
	}
}
