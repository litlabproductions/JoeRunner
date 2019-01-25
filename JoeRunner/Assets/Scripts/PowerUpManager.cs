using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    private bool doublePoints;
    private bool safeMode;

    private bool powerUpActive;

    private float powerUpLengthCounter;

    private UIManager theUIManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;

    private GameManager theGameManger;

    // Use this for initialization
    void Start ()
    {
        theUIManager = FindObjectOfType<UIManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManger = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (powerUpActive)
        {
            powerUpLengthCounter -= Time.deltaTime;

            if (theGameManger.powerupReset = true)
            {
                powerUpLengthCounter = 0;
                theGameManger.powerupReset = false;
            }

            if (doublePoints)
            {
                theUIManager.pointerPerSecond = normalPointsPerSecond * 2f;
                theUIManager.shouldDouble = true;
            }

            if (safeMode)
                thePlatformGenerator.randomSpikeThreshold = 0f;

            if (powerUpLengthCounter <= 0)
            {
                theUIManager.pointerPerSecond = normalPointsPerSecond;
                theUIManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                powerUpActive = false;
            }
        }
	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerUpLengthCounter = time;

        normalPointsPerSecond = theUIManager.pointerPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;
        if (safeMode)
        { 
            spikeList = FindObjectsOfType<PlatformDestroyer>();

            for (int i = 0; i < spikeList.Length; i++)
                if(spikeList[i].gameObject.name.Contains("spikes"))
                    spikeList[i].gameObject.SetActive(false);
        }

        powerUpActive = true;
    }
}
