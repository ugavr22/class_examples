using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionSpeed;
    public float endRadius;
    public float startRadius;
    private float currentRadius;
    // Start is called before the first frame update
    void Start()
    {
        currentRadius = startRadius;
    }

    // Update is called once per frame
    void Update()
    {
        currentRadius += explosionSpeed * Time.deltaTime;
        transform.localScale = Vector3.one * (currentRadius * 2);
        if(currentRadius > endRadius)
		{
            GameObject.Destroy(this.gameObject);
		}
    }
}
