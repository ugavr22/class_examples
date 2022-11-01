using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
public class NetworkGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VelNetManager.OnLoggedIn += () => {
            VelNetManager.Join("myroom");
        };
        VelNetManager.OnJoinedRoom += (roomname) => {
            VelNetManager.NetworkInstantiate("Player");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
