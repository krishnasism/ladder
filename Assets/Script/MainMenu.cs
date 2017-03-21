using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class MainMenu : MonoBehaviour 
{
	#if UNITY_ANDROID
	string adUnitId="ca-app-pub-3726539248374535/3220283005";
	#endif
	BannerView bannerView;
	AdRequest request;
	public Text scoreText;
	private void Start()
	{
		bannerView=new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		request=new AdRequest.Builder().Build();
		scoreText.text = PlayerPrefs.GetInt ("score").ToString();
		bannerView.LoadAd(request);
		bannerView.Show ();
	}
	public void ToGame()
	{
		SceneManager.LoadScene("Game");
	}
	public void ExitGameNow()
	{
		bannerView.Destroy ();
		Caching.CleanCache();
		Application.Quit();
	}
    public void InstructionScreen()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
