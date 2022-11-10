using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelNetPlayer : MonoBehaviour
{
    public VRPlayer myPlayer;
    public Transform head, leftHand, rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayer == null)
		{
            return;
		}
        head.position = myPlayer.head.position;
        head.rotation = myPlayer.head.rotation;

        leftHand.position = myPlayer.hands[0].transform.position;
        leftHand.rotation = myPlayer.hands[0].transform.rotation;

        rightHand.position = myPlayer.hands[1].transform.position;
        rightHand.rotation = myPlayer.hands[1].transform.rotation;
        transform.position = myPlayer.transform.position;
    }
}
