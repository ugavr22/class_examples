using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
using TMPro;
using VELConnect;
using UnityEngine.XR.Management;
using UnityEngine.XR.ARCore;
using Unity.XR.Oculus;
using UnityEngine.XR.OpenXR;

public class NetworkGameManager : MonoBehaviour
{
    //[SerializeField] NetworkObject testNO;
    // Start is called before the first frame update
    [SerializeField] VRPlayer myPlayer;
    [SerializeField] TMP_Text codeText;
    [SerializeField] VelNetPlayer localPlayer;
    [SerializeField] SyncWebRTCUrl rtc;
    [SerializeField] VelVoice velVoice;
    [SerializeField] TMP_Text debugText;
    [SerializeField] GameObject ovrRig;
    [SerializeField] GameObject arRig;




    void Start()
    {
        for (int i = 0; i < XRGeneralSettings.Instance.Manager.activeLoaders.Count; i++)
		{
            XRLoader loader = XRGeneralSettings.Instance.Manager.activeLoaders[i];
            if (loader.GetType() == typeof(ARCoreLoader)){
                arRig.SetActive(true);
            }
            if (loader.GetType() == typeof(OculusLoader) || loader.GetType()==typeof(OpenXRLoader))
            {
                ovrRig.SetActive(true);
            }

        }
        


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

        velVoice.startMicrophone(Microphone.devices[0]); //change this if not default microphone
    }

    void onDeviceDataChanged(string key, string value)
	{
        Debug.Log(key + "," + value);
        if(key == "avatar_url" && localPlayer != null)
		{
            localPlayer.loadAvatar(value);
		}
        if(key == "streamer_stream_id")
		{
            rtc.setRoom(value);
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
