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
        //head.rotation = Quaternion.Euler(0, headRotation, 0);
     
        //head.rotation = Quaternion.AngleAxis(headRotation, (new Vector3(.5f,3f,-2f)).normalized);
        //Debug.Log(head.rotation.eulerAngles);
        //head.rotation = Quaternion.LookRotation(Vector3.up,Vector3.back);

        Vector3 mouthInWorld = head.localToWorldMatrix.MultiplyPoint(Vector3.forward);
        Vector3 mouthInPlane = ball.parent.worldToLocalMatrix.MultiplyPoint(mouthInWorld);
        //ball.position = head.position + head.forward;
        //ball.localPosition = mouthInPlane;

        //make head look at ball
        Vector3 headToBall = ball.position - head.position;
        //head.rotation = Quaternion.LookRotation(headToBall.normalized);
        //head.forward = headToBall.normalized;
        head.LookAt(ball);

        //Quaternion.Slerp() used to average quaternions 
        //Vector3.Lerp() used to average vectors
        //Vector3.Cross() used to find the cross product of two vectors
        //Vector3.Angle / Vector3.SignedAngle used to find the angle between two vectors

    }
}
