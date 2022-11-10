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

	public void rpcReceiveMessage(byte[] message)
	{
		MemoryStream mem = new MemoryStream(message);
		BinaryReader reader = new BinaryReader(mem);
		string sent = reader.ReadString();
		Debug.Log("got a message: " + sent);
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
			if (Input.GetKeyDown(KeyCode.R))
			{
				MemoryStream mem = new MemoryStream();
				BinaryWriter writer = new BinaryWriter(mem);

				writer.Write("my message");

				this.SendRPC("rpcReceiveMessage", false, mem.ToArray());
			}
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, targetPosition, .3f);
		}
    }
}
