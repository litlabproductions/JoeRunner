using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;

    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private UIManager theUIManger;

    public DeathMenu theDeathScreen;

    public bool powerupReset;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theUIManger = FindObjectOfType<UIManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        //StartCoroutine("RestartGameCo");
        theUIManger.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);

    }

    public void Reset()
    {
   
        platformList = FindObjectsOfType<PlatformDestroyer>();

       // for (int i = 0; i < platformList.Length; i++)
        //    platformList[i].gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(false);
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theUIManger.scoreCount = 0;
        theUIManger.scoreIncreasing = true;

        powerupReset = true;
    }
    /*
 
    public IEnumerator RestartGameCo()   // ~ Pause for half a second.
    {
        theScoreManger.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
            platformList[i].gameObject.SetActive(false);

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManger.scoreCount = 0;
        theScoreManger.scoreIncreasing = true;
    }    */
}
