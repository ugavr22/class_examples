using ReadyPlayerMe;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VelNet;
public class VelNetPlayer : NetworkSerializedObjectStream
{
    public VRPlayer myPlayer;
    public Transform head, leftHand, rightHand;
    public GameObject avatar;
	protected override void ReceiveState(BinaryReader binaryReader)
	{
		//throw new System.NotImplementedException();
	}

	protected override void SendState(BinaryWriter binaryWriter)
	{
		//throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }
    public void loadAvatar(string url)
	{
        MemoryStream mem = new MemoryStream();
        BinaryWriter writer = new BinaryWriter(mem);
        writer.Write(url);
        SendRPC("doLoadAvatar", true, mem.ToArray());
        
	}

    public void doLoadAvatar(byte[] data)
	{
        MemoryStream mem = new MemoryStream(data);
        BinaryReader reader = new BinaryReader(mem);
        string url = reader.ReadString();
        var avatarLoader = new AvatarLoader();
        avatarLoader.OnCompleted += (_, args) =>
        {
            avatar = args.Avatar;
            Transform rh = avatar.transform.FindChildRecursive("RightHand");
            Transform lh = avatar.transform.FindChildRecursive("LeftHand");
        };
        avatarLoader.LoadAvatar(url);
        //Debug.Log(url);
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayer == null || avatar == null)
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
