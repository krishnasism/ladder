using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Instruction : MonoBehaviour {
    int gameScore;
    InterstitialAd interstitial;
    AdRequest request;
    string AdUnitInter = "ca-app-pub-3726539248374535/7650482601";
    private void Start()
    {
        gameScore = PlayerPrefs.GetInt("score");
        // Initialize an InterstitialAd.
        if (gameScore <= 40)
        {
            interstitial = new InterstitialAd(AdUnitInter);
            // Create an empty ad request.
            request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            // Advertisement.Initialize ("1221838"); //CHECK
            interstitial.LoadAd(request);
        }
    }
    public void BackToMenu()
    {
        if (gameScore <= 40)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }
        SceneManager.LoadScene("Menu");
    }
}
