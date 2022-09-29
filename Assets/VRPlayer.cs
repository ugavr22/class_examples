using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{

    public enum GRIP_STATE { OPEN, OBJECT, AIR}
    public enum TELEPORT_STATE { ACTIVE, WAITING }


    public float teleportThresholdActivate;
    public float teleportThresholdDeactivate;

    public float gripThresholdActivate;
    public float gripThresholdDeactivate;


    public Vector2[] joyValues = new Vector2[2];
    public TELEPORT_STATE[] teleportStates = new TELEPORT_STATE[] { TELEPORT_STATE.WAITING, TELEPORT_STATE.WAITING };

    public float[] gripValues = new float[2] { 0, 0 };
    public GRIP_STATE[] gripStates = new GRIP_STATE[2] { GRIP_STATE.OPEN, GRIP_STATE.OPEN };
    public Vector3[] gripLocations = new Vector3[2];
    public VRHand[] hands = new VRHand[2];
    Vector3[] cameraRigGripLocation = new Vector3[2];
    public VRGrabbable[] grabbedObjects = new VRGrabbable[2] { null, null };



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gripValues[0] = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        gripValues[1] = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        joyValues[0] = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        joyValues[1] = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        




        Vector3[] displacements = new Vector3[2];
        for(int i = 0; i < 2; i++) //the two hands
		{

            //teleporting
            if(teleportStates[i] == TELEPORT_STATE.WAITING)
			{
                if(joyValues[i].y > teleportThresholdActivate)
				{
                    teleportStates[i] = TELEPORT_STATE.ACTIVE;
				}
			}
			else if(teleportStates[i] == TELEPORT_STATE.ACTIVE)
			{
                if(joyValues[i].y < teleportThresholdDeactivate)
				{
                    //do the teleport
                    Vector3 teleportOffset = hands[i].transform.forward;
                    teleportOffset.y = 0;
                    teleportOffset.Normalize();
                    this.transform.position += teleportOffset;
                    teleportStates[i] = TELEPORT_STATE.WAITING;
				}
			}

            //gripping

            displacements[i] = Vector3.zero;
			if (gripStates[i] == GRIP_STATE.AIR) //we are gripping the air, handle movement and release
			{

                if(gripValues[i] < gripThresholdDeactivate)
				{
                    gripStates[i] = GRIP_STATE.OPEN;
				}else 
				{
                    Vector3 handInTracking = transform.worldToLocalMatrix.MultiplyPoint(hands[i].transform.position);
                    Vector3 between = handInTracking - gripLocations[i];

                    displacements[i] = - between;

				}

			} 
            else if (gripStates[i] == GRIP_STATE.OBJECT)
			{
                //this hand is gripping an object
                if (gripValues[i] < gripThresholdDeactivate)
                {
                    //release it
                    gripStates[i] = GRIP_STATE.OPEN;
                }
                else
                {
                    //cause it to move
                    VRGrabbable g = grabbedObjects[i];
                    Rigidbody rb = g.GetComponent<Rigidbody>();

                    Vector3 between = hands[i].grabOffset.position - g.transform.position;
                    Vector3 direction = between.normalized;

                    rb.velocity = between / Time.deltaTime;

                    Quaternion betweenRot = hands[i].grabOffset.rotation * Quaternion.Inverse(g.transform.rotation);
                    Vector3 axis;
                    float angle;
                    betweenRot.ToAngleAxis(out angle, out axis);

                    rb.angularVelocity = angle * Mathf.Deg2Rad * axis / Time.deltaTime;

                }



            }
            else //not gripping, handle grip activate
			{
                if(gripValues[i] > gripThresholdActivate)
                    if(hands[i].grabbables.Count == 0) //nothing to grab
				    {
                        gripStates[i] = GRIP_STATE.AIR; //now we are gripping air
                        Vector3 handInTracking = transform.worldToLocalMatrix.MultiplyPoint(hands[i].transform.position);

                        gripLocations[i] = handInTracking;
                        cameraRigGripLocation[i] = this.transform.position;
					}
					else
					{
                        gripStates[i] = GRIP_STATE.OBJECT;
                        grabbedObjects[i] = hands[i].grabbables[0]; //just grab the first objecct
                        hands[i].grabOffset.transform.position = grabbedObjects[i].transform.position;
                    }
			}

		}

        if(gripStates[0] == GRIP_STATE.AIR && gripStates[1] == GRIP_STATE.AIR)
		{
            this.transform.position = (cameraRigGripLocation[0] + displacements[0] + cameraRigGripLocation[1] + displacements[1]) / 2.0f;

        }else if (gripStates[0] == GRIP_STATE.AIR)
		{
            this.transform.position = cameraRigGripLocation[0] + displacements[0];

		}
		else if (gripStates[1] == GRIP_STATE.AIR)
		{
            this.transform.position = cameraRigGripLocation[1] + displacements[1];
        }

        //Debug.Log(leftHandTrigger + "," + rightHandTrigger);



    }


}
