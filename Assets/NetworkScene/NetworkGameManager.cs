using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
public class NetworkGameManager : MonoBehaviour
{
    [SerializeField] NetworkObject testNO;
    // Start is called before the first frame update
    void Start()
    {
        VelNetManager.OnLoggedIn += () => {
            VelNetManager.Join("myroom2");
        };
        VelNetManager.OnJoinedRoom += (roomname) => {
            VelNetManager.NetworkInstantiate("Player");
        };
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            testNO.TakeOwnership();
		}
    }
}
