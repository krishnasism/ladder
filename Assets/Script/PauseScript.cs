using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    // Use this for initialization
    public Transform canvas;
    public Transform canvas2;
    // Update is called once per frame
    void Update() {
        if (canvas2.gameObject.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canvas.gameObject.activeInHierarchy == false)
                {
                    canvas.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    canvas.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
	}
    public void ResumeGame()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
