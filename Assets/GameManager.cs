using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //directly assigned in the inspector
    [SerializeField] VRPlayer player;
    [SerializeField] List<SearchObject> objectsToFind; 
    [SerializeField] List<HidingLocation> hidingLocations; 
    [SerializeField] List<TargetLocation> targetLocations;
    [SerializeField] Transform startLocation;
    [SerializeField] StartButton startButton;

    public enum GAME_STATE { IDLE, STARTED, FINISHED }
    public GAME_STATE gameState = GAME_STATE.IDLE;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        startButton.buttonPressed += startPressed;
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(resetGame());
    }

    void startPressed(VRHand hand)
	{
        if (gameState == GAME_STATE.IDLE)
        {
            startGame();
        }
        else if(gameState == GAME_STATE.STARTED)
		{

            bool gameFinished = true;
            foreach(TargetLocation t in targetLocations)
			{
				if (!t.isFound)
				{
                    gameFinished = false;
                    break;
				}
			}

            //end game
            endGame();

		}
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
        gameState = GAME_STATE.STARTED;
	}

    public void endGame()
	{
        SceneManager.LoadScene(0);
	}

    public IEnumerator resetGame()
	{
        yield return new WaitForSeconds(1.0f);
        player.doTeleport(startLocation.position);
        yield return new WaitForSeconds(1.0f);

    }
}
