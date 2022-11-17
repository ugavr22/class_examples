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

    void Start()
    {
        VelNetManager.OnLoggedIn += () => {
            VelNetManager.Join("myroom3");
        };
        VelNetManager.OnJoinedRoom += (roomname) => {
            NetworkObject player = VelNetManager.NetworkInstantiate("Player");
            player.GetComponent<VelNetPlayer>().loadAvatar("https://api.readyplayer.me/v1/avatars/6373d2e55764c3e56af74cd6.glb");
            player.GetComponent<VelNetPlayer>().myPlayer = myPlayer;
        };

        codeText.text = ""+VELConnectManager.PairingCode;

        VELConnectManager.OnInitialState += (state) => { 
            
        };
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
