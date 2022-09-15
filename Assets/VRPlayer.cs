using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
   
    public float gripThresholdActivate;
    public float gripThresholdDeactivate;


    public float[] gripValues = new float[2] { 0, 0 };
    public bool[] gripStates = new bool[2] { false, false };
    public Vector3[] gripLocations = new Vector3[2];
    public Transform[] hands = new Transform[2];
    Vector3[] cameraRigGripLocation = new Vector3[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gripValues[0] = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        gripValues[1] = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        
        Vector3[] displacements = new Vector3[2];
        for(int i = 0; i < 2; i++)
		{
            displacements[i] = Vector3.zero;
			if (gripStates[i]) //we are gripping, handle movement and release
			{

                if(gripValues[i] < gripThresholdDeactivate)
				{
                    gripStates[i] = false;
				}else 
				{
                    Vector3 handInTracking = transform.worldToLocalMatrix.MultiplyPoint(hands[i].position);
                    Vector3 between = handInTracking - gripLocations[i];

                    displacements[i] = - between;

				}

			} else //not gripping, handle grip activate
			{
                if(gripValues[i] > gripThresholdActivate)
				{
                    gripStates[i] = true; //now we are gripping
                    Vector3 handInTracking = transform.worldToLocalMatrix.MultiplyPoint(hands[i].position);

                    gripLocations[i] = handInTracking;
                    cameraRigGripLocation[i] = this.transform.position;
				}
			}

		}

        if(gripStates[0] && gripStates[1])
		{
            this.transform.position = (cameraRigGripLocation[0] + displacements[0] + cameraRigGripLocation[1] + displacements[1]) / 2.0f;

        }else if (gripStates[0])
		{
            this.transform.position = cameraRigGripLocation[0] + displacements[0];

		}
		else if (gripStates[1])
		{
            this.transform.position = cameraRigGripLocation[1] + displacements[1];
        }

        //Debug.Log(leftHandTrigger + "," + rightHandTrigger);



    }
}
