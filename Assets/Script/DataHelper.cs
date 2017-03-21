using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using UnityEngine.UI;


public class DataHelper : MonoBehaviour {

	int gameScore; 
	int timesLost;
	public Text scoreText;
	void Start()
	{
		gameScore= PlayerPrefs.GetInt ("score");
		timesLost= PlayerPrefs.GetInt("lost");
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success)
				{
						if(gameScore>=10) //babysteps
						{
							Social.ReportProgress(LadderResources.achievement_baby_steps,100.0f,(bool success2) =>
								{});
						}	
						if(gameScore>=15)
						{
								Social.ReportProgress(LadderResources.achievement_going_up_the_ladderboard,100.0f,(bool success2) =>
									{});	
						}		

						if(gameScore>=20)
						{
								Social.ReportProgress(LadderResources.achievement_stepping_up_your_game,100.0f,(bool success2) =>
									{});	
						}
						if(gameScore>=40)
						{
								Social.ReportProgress(LadderResources.achievement_up__up,100.0f,(bool success2) =>
									{});	
						}
						if(gameScore>=42)
						{
								Social.ReportProgress(LadderResources.achievement_ladder_to_the_galaxy,100.0f,(bool success2) =>
									{});	
						}
						if(gameScore>=50)
						{
								Social.ReportProgress(LadderResources.achievement_steep_stooper,100.0f,(bool success2) =>
									{});	
						}
						if(gameScore>=100)
						{
								Social.ReportProgress(LadderResources.achievement_step_it_off,100.0f,(bool success2) =>
									{});	
						}
						if(gameScore>=150)
						{
								Social.ReportProgress(LadderResources.achievement_bigfoot,100.0f,(bool success2) =>
									{});	
						}
						if(gameScore>=200)
						{
								Social.ReportProgress(LadderResources.achievement_ladder_makes_me_madder,100.0f,(bool success2) =>
									{});	
						}
						if(timesLost>=20)
						{
							Social.ReportProgress(LadderResources.achievement_step_bye_step,100.0f,(bool success2) =>
									{});
						}
						if(timesLost>=50)
						{
							Social.ReportProgress(LadderResources.achievement_slippery_steps,100.0f,(bool success2) =>
									{});
						}
						if(timesLost>=100)
						{
							Social.ReportProgress(LadderResources.achievement_snakes__ladders,100.0f,(bool success2) =>
									{});
						}

					} 
					else 
					{
					}
				});
			submitScore ();
	}
	public void openAchievement()
	{
		//PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					//flag=1;
					Social.ShowAchievementsUI ();
				} else 
				{
				}
			});

	}
	public void showLeaderBoard()
	{
		//PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					//flag=1;
					Social.ShowLeaderboardUI ();
				} else 
				{
				}
			});	
	}
	public void submitScore()
	{
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success)
				{
					Social.ReportScore(gameScore,"CgkI9dTc4PwWEAIQBw",(bool successx) =>
						{
							if(successx){}
							else{}
						});
				}
						else 
					{
					}
					});	
	}
}
