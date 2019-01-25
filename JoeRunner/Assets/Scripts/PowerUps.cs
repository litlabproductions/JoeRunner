using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool doublePoints;
    public bool safeMode;
    public float powerUpLength;


    private PowerUpManager thePowerUpManager;

    public   Sprite[] powerupSprites;




	// Use this for initialization
	void Start () {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();

	}
	
	void Awake()
    {
        int powerupSelector = Random.Range(0, 2);

        switch (powerupSelector)
        {
            case 0:
                doublePoints = true;
                break;

            case 1:
                safeMode = true;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePowerUpManager.ActivatePowerup (doublePoints, safeMode, powerUpLength);
        }
        gameObject.SetActive(false);
    }
}
