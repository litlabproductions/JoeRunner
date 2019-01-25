using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {

    public int scoreToGive;

    private UIManager theUIManager;

    private AudioSource coinSound;

	// Use this for initialization
	void Start () {
        theUIManager = FindObjectOfType<UIManager>();

        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theUIManager.AddScore(scoreToGive);
            gameObject.SetActive(false);

            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
                coinSound.Play();
        }
    }
}
