using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VelNet;
public class SyncWebRTCUrl : NetworkSerializedObjectStream
{
    WebRTCManager manager;
    // Start is called before the first frame update
    void Start()
    {
        this.manager = GetComponent<WebRTCManager>();
    }


    public void setRoom(string room)
	{
        this.networkObject.TakeOwnership();
        manager.streamRoom = room;
        manager.Reload();
    }

	protected override void SendState(BinaryWriter binaryWriter)
	{
        binaryWriter.Write(manager.streamRoom);
	}

	protected override void ReceiveState(BinaryReader binaryReader)
	{
        string room = binaryReader.ReadString();
        if(room != manager.streamRoom)
		{
            manager.streamRoom = room;
            manager.Reload();
        }
	}
}
