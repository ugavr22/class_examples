using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform head;
    public Transform ball;
    public float headRotation;
    public float headSpeed;
    // Start is called before the first frame update
    void Start()
    {
        headSpeed = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        //ball.position
        headRotation += headSpeed * Time.deltaTime;
        head.rotation = Quaternion.Euler(0, headRotation, 0);

        Vector3 mouthInWorld = head.localToWorldMatrix.MultiplyPoint(Vector3.forward);
        Vector3 mouthInPlane = ball.parent.worldToLocalMatrix.MultiplyPoint(mouthInWorld);
        //ball.position = head.position + head.forward;
        ball.localPosition = mouthInPlane;

    }
}
