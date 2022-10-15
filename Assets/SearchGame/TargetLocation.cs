using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TargetLocation : MonoBehaviour
{
    [SerializeField] Color foundColor;
    [SerializeField] Color notFoundColor;
    [SerializeField] GameObject targetCollider;
    public SearchObject target;
    public bool isFound;
    public TMP_Text label3d;

    // Start is called before the first frame update
    void Start()
    {
        label3d.text = target.label;
        targetCollider.GetComponent<Renderer>().material.color = notFoundColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        SearchObject so = rb.GetComponent<SearchObject>();
        if (so == null) return;
        if(so == target)
		{
            isFound = true;
            targetCollider.GetComponent<Renderer>().material.color = foundColor;

		}
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        SearchObject so = rb.GetComponent<SearchObject>();
        if (so == null) return;
        if(so == target)
		{
            isFound = false;
            targetCollider.GetComponent<Renderer>().material.color = notFoundColor;
        }
    }
}
