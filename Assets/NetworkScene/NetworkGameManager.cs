using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
public class NetworkGameManager : MonoBehaviour
{
    //[SerializeField] NetworkObject testNO;
    // Start is called before the first frame update
    [SerializeField] VRPlayer myPlayer;
    void Start()
    {
        VelNetManager.OnLoggedIn += () => {
            VelNetManager.Join("myroom2");
        };
        VelNetManager.OnJoinedRoom += (roomname) => {
            NetworkObject player = VelNetManager.NetworkInstantiate("Player");
            player.GetComponent<VelNetPlayer>().loadAvatar("https://api.readyplayer.me/v1/avatars/636d3fb22d953b6ac1d9187a.glb");
            player.GetComponent<VelNetPlayer>().myPlayer = myPlayer;
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
