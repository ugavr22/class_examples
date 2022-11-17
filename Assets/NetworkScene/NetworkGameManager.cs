using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
using TMPro;
using VELConnect;
public class NetworkGameManager : MonoBehaviour
{
    //[SerializeField] NetworkObject testNO;
    // Start is called before the first frame update
    [SerializeField] VRPlayer myPlayer;
    [SerializeField] TMP_Text codeText;
    [SerializeField] VelNetPlayer localPlayer;
    void Start()
    {
        VelNetManager.OnLoggedIn += () => {
            VelNetManager.Join("myroom3");
        };
        VelNetManager.OnJoinedRoom += (roomname) => {
            NetworkObject player = VelNetManager.NetworkInstantiate("Player");
            localPlayer = player.GetComponent<VelNetPlayer>();
            string avatar_url = VELConnectManager.GetDeviceData("avatar_url");
            localPlayer.loadAvatar(avatar_url);
            //localPlayer.loadAvatar(null);
            localPlayer.myPlayer = myPlayer;
        };

        codeText.text = ""+VELConnectManager.PairingCode;
        VELConnectManager.OnDeviceDataChanged += onDeviceDataChanged;
    }

    void onDeviceDataChanged(string key, string value)
	{
        if(key == "avatar_url" && localPlayer != null)
		{
            localPlayer.loadAvatar(value);
		}
	}

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.Space))
		//{
        //    testNO.TakeOwnership();
		//}
    }
}
