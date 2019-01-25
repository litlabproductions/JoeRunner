using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private const string INSTAGRAM_URL = "https://www.instagram.com/litlab.productions/";

    public void OnPlayClick()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void OnRateClick()
    {
        Application.OpenURL(INSTAGRAM_URL);
     
    }
    public void TutorialClick()
    {

    }
}
