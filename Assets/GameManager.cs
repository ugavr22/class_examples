using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //directly assigned in the inspector
    [SerializeField] VRPlayer player;
    [SerializeField] List<SearchObject> objectsToFind; 
    [SerializeField] List<HidingLocation> hidingLocations; 
    [SerializeField] List<TargetLocation> targetLocations;
    [SerializeField] Transform startLocation;
    [SerializeField] StartButton startButton;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        startButton.buttonPressed += startPressed;
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(resetGame());
    }

    void startPressed(VRHand hand)
	{
        startGame();
	}
    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
	{
        foreach(SearchObject so in objectsToFind)
		{
            so.gameObject.SetActive(true);
		}
        
	}

    public IEnumerator resetGame()
	{
        yield return new WaitForSeconds(1.0f);
        player.doTeleport(startLocation.position);
        yield return new WaitForSeconds(1.0f);

    }
}
