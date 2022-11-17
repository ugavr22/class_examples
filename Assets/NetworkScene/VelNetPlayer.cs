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
    string avatarURL = "";
	protected override void ReceiveState(BinaryReader binaryReader)
	{
        string url = binaryReader.ReadString();
        if(url != avatarURL)
		{
            loadAvatar(url);
		}

        if(head == null)
		{
            return;
		}

        head.position = binaryReader.ReadVector3();
        head.rotation = binaryReader.ReadQuaternion();

        leftHand.position = binaryReader.ReadVector3();
        leftHand.rotation = binaryReader.ReadQuaternion();

        rightHand.position = binaryReader.ReadVector3();
        rightHand.rotation = binaryReader.ReadQuaternion();

        transform.position = binaryReader.ReadVector3();
        transform.rotation = binaryReader.ReadQuaternion();
    }

	protected override void SendState(BinaryWriter binaryWriter)
	{
        if(avatar == null)
		{
            return;
		}
        binaryWriter.Write(avatarURL);
        //throw new System.NotImplementedException();
        binaryWriter.Write(head.position);
        binaryWriter.Write(head.rotation);
        binaryWriter.Write(leftHand.position);
        binaryWriter.Write(leftHand.rotation);
        binaryWriter.Write(rightHand.position);
        binaryWriter.Write(rightHand.rotation);
        binaryWriter.Write(transform.position);
        binaryWriter.Write(transform.rotation);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }
    public void loadAvatar(string url)
	{
        avatarURL = url;
        var avatarLoader = new AvatarLoader();
        avatarLoader.OnCompleted += (_, args) =>
        {
            avatar = args.Avatar;
            rightHand = avatar.transform.FindChildRecursive("RightHand");
            leftHand = avatar.transform.FindChildRecursive("LeftHand");
            head = avatar.transform.FindChildRecursive("Hips");

        };
        avatarLoader.LoadAvatar(url);

    }

   

    // Update is called once per frame
    void Update()
    {
        if(myPlayer == null || avatar == null)
		{
            return;
		}
		if (networkObject.IsMine)
		{
            head.position = myPlayer.head.position;
            head.rotation = myPlayer.head.rotation;

            leftHand.position = myPlayer.rpmOffsets[0].position;
            leftHand.rotation = myPlayer.rpmOffsets[0].rotation;

            rightHand.position = myPlayer.rpmOffsets[1].position;
            rightHand.rotation = myPlayer.rpmOffsets[1].rotation;

            transform.position = myPlayer.transform.position;
            transform.rotation = myPlayer.transform.rotation;
		}
       
    }
}
