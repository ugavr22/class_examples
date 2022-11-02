using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VelNet;
public class MySyncTransform : NetworkSerializedObjectStream
{
	Vector3 targetPosition;
	protected override void ReceiveState(BinaryReader binaryReader)
	{
		targetPosition = binaryReader.ReadVector3();
	}

	protected override void SendState(BinaryWriter binaryWriter)
	{
		binaryWriter.Write(transform.position);
	}

	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if (networkObject.IsMine)
		{

		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, targetPosition, .3f);
		}
    }
}
