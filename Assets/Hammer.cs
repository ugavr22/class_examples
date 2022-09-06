using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Explosion explosionPrefab;
	GameObject hammerHead;
    // Start is called before the first frame update
    void Start()
    {
		hammerHead = transform.Find("Head").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log(collision.body);
		
        Collider c = collision.contacts[0].thisCollider;

		if (c.gameObject == hammerHead )
		{
			Explosion e = Instantiate(explosionPrefab);
			e.transform.position = collision.contacts[0].point;
			e.endRadius = 1;
			e.startRadius = .1f;
			e.explosionSpeed = 1;
		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		Explosion e = Instantiate(explosionPrefab);
		e.transform.position = other.transform.position;
		e.endRadius = 1;
		e.startRadius = .1f;
		e.explosionSpeed = 1;
	}

}
