using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
        // ~ GO ahead of the player.
    public GameObject thePlatform;
    public Transform generationPoint;    // ~ Point determining if there is a platform.
    public float distanceBetween;   // ~ D between platforms.

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;

    private int platformSelector;
    private float[] platformWidths;

 
    private float minHeight;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float maxHeight;
    public float maxHeightChange;

    private float heightChange;

        // ~ Referance to obj pooler
   public ObjectPooler[] theObjectPools;

    private CoinGenerator theCoinGenerator;

    public float randomCoinThreshold;

    public float randomSpikeThreshold;
    public ObjectPooler spikePool;


    // ~ Power up pos.
    public float powerUpHeight;
    public ObjectPooler powerUpPool;
    public float powerUpThreshold;

	    // Use this for initialization
	void Start ()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;  

        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = 
            minHeightPoint.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }
	
    
	    // Update is called once per frame
	void Update ()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = 2;
                //Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);

            if (heightChange > maxHeight)
                heightChange = 0;
                    //maxHeight;
            if (heightChange < minHeight)
                heightChange = 0;
                    //minHeight;

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] +5f), heightChange, transform.position.z);
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < powerUpThreshold)
            {
                GameObject newPowerup = powerUpPool.GetPooledObject();
                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(powerUpHeight / 2, powerUpHeight), 0f);

                newPowerup.SetActive(true);
            }

           // transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

           // Instantiate(/*thePlatform*/ theObjectPools[platformSelector], transform.position, transform.rotation);
                
                // ~ Set a new Game obj to that of a plat from the pooled list.
        
            if (Random.Range(0f, 100f) < randomCoinThreshold)
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));

            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2  + 1f, platformWidths[platformSelector] / 2 - 1f);

                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            
            }
            

        }
    }
}
