using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BackButton : MonoBehaviour {
    InterstitialAd interstitial;
    AdRequest request;
    string AdUnitInter = "ca-app-pub-3726539248374535/7650482601";
    int gameScore;
    private void Start()
    {
        gameScore = PlayerPrefs.GetInt("score");
        if (gameScore <= 40)
        {
            // Initialize an InterstitialAd.
            interstitial = new InterstitialAd(AdUnitInter);
            // Create an empty ad request.
            request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            // Advertisement.Initialize ("1221838"); //CHECK
            interstitial.LoadAd(request);
        }
    }
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (gameScore <= 40)
            {
                if (interstitial.IsLoaded())
                {
                    interstitial.Show();
                }
            }
            SceneManager.LoadScene ("Menu");
		}
	}
}
