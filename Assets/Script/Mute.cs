using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

	bool isMute=false;
	public Sprite iconmuted;
	public Sprite iconNotMuted;
	public Button button;
	int isMutein=0; 
 	 public void Start()
 	 {
    	 if(AudioListener.volume==0)
    	 {
    	 	button.image.overrideSprite = iconmuted;
    	 }
    	 else
    	 {
    	 	button.image.overrideSprite = iconNotMuted;
    	 }
 	 }
	 public void MuteClick ()
	 {
    	 isMute = ! isMute;
    	 AudioListener.volume =  isMute ? 0 : 1;
    	 if(isMute)
    	 {
    	 	button.image.overrideSprite = iconmuted;
    	 }
    	 else
    	 {
    	 	button.image.overrideSprite = iconNotMuted;
    	 }
	}
}
