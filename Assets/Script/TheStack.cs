using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheStack : MonoBehaviour 
{
	public Text ScoreText;

	public Color32[] gameColors = new Color32[4];
	private GameObject[] theStack;
	public GameObject endPanel;

	private int lose=0;
	private int prevlose=0;
	private int scoreCount=0;
	private int stackIndex;
	public int total_score =0;

	private const float BOUNDS_SIZE = 4.0f;
	private float tileTransition = 0.0f;
	private float tileSpeed = 1.7f;
	private const float STACK_MOVING_SPEED = 5.0f;
	private float ERROR_MARGIN = 0.20f;
	private float ERROR_MARGIN_Z = 0.20f;
	private float secondaryPosition;

	private bool isMovingOnX = true;
	private bool gameOver = false;

	private Vector3 desiredPosition;
	private Vector3 lastTilePosition;

    private int tutclick = 0;
    
    public Transform canvas;
    int gameScore;
    private void Start ()
	{
        gameScore = PlayerPrefs.GetInt("score");
		prevlose=PlayerPrefs.GetInt("lost");
		theStack = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
		{
			theStack [i] = transform.GetChild (i).gameObject;
		}
		stackIndex = transform.childCount - 1;				
	}
	

	void Update () 
	{
        if (canvas.gameObject.activeInHierarchy == false)  //check if pause menu is open
        {
            Time.timeScale = 1; //resume time

            if (gameOver)
                return;
            if (Input.GetMouseButtonDown(0))
            {
                tutclick++;
                if (tutclick > 5)
                {
                    ERROR_MARGIN = 0.175f;
                    ERROR_MARGIN_Z = 0.175f;
                }
                if (PlaceTile())
                {
                    scoreCount = scoreCount + 2; //track no. of times clicked
                                                 //incrementing difficulty
                    tileSpeed = tileSpeed + 0.01f;
      
                    if (tileSpeed + 0.01f > 3.0f)
                    {
                        tileSpeed = 3.0f;
                    }
                    spawnTile(); //place a stair on top of the stack
                }
                else
                {

                    EndGame();
                }
            }
            MoveTile();

            //move whole stack
            transform.position = Vector3.Lerp(transform.position, desiredPosition, STACK_MOVING_SPEED * Time.deltaTime);
        }
        else
        {
            return;
        }

	}


	private void MoveTile()
	{
		tileTransition += Time.deltaTime * tileSpeed;
		if (isMovingOnX)
		{
			theStack [stackIndex].transform.localPosition = new Vector3 (Mathf.Sin (tileTransition) * BOUNDS_SIZE, scoreCount, secondaryPosition); //DEBUG
		}
		else 
		{
			theStack [stackIndex].transform.localPosition = new Vector3 (secondaryPosition, scoreCount, Mathf.Sin (tileTransition) * BOUNDS_SIZE); //DEBUG
		}
	}


	private void spawnTile()
	{
		lastTilePosition = theStack [stackIndex].transform.localPosition;
		stackIndex--;
		if (stackIndex < 0) {
			stackIndex = transform.childCount-1;
		}
		desiredPosition = (Vector3.down) * scoreCount; //DEBUG
		theStack [stackIndex].transform.localPosition = new Vector3 (0, scoreCount, 0);	//DEBUG
		ColorMesh(theStack [stackIndex].GetComponent<MeshFilter> ().mesh);
	}


	private bool PlaceTile() 
	{
		Transform t = theStack [stackIndex].transform;
		if (isMovingOnX) 
		{
			float deltaX = lastTilePosition.x - t.position.x;
			if (Mathf.Abs (deltaX) > ERROR_MARGIN)
			{

			
				return false;
				
			} 
			else 
			{
				
				total_score++;	
				ScoreText.text = total_score.ToString ();
				t.localPosition = new Vector3 (lastTilePosition.x, scoreCount, lastTilePosition.z); //DEBUG
				
			}


		} 
		else 
		{
			float deltaZ = lastTilePosition.z - t.position.z;
			if (Mathf.Abs (deltaZ) > ERROR_MARGIN_Z)
			{
				
				return false;
				
			}
			//zposition
			else
			{
				total_score++;
				ScoreText.text = total_score.ToString ();
				t.localPosition = new Vector3 (lastTilePosition.x, scoreCount, lastTilePosition.z); //DEBUG
				//t.localPosition = lastTilePosition + Vector3.up;

			}
			
		}

		secondaryPosition = (isMovingOnX) ? (t.localPosition.x) : (t.localPosition.z);
		isMovingOnX = !isMovingOnX;

		return true;
	}

	private void ColorMesh(Mesh mesh)
	{
		Vector3[] vertices = mesh.vertices;
		Color32[] colors = new Color32[vertices.Length];
		float f=Mathf.Sin(scoreCount*0.25f);
		for (int i = 0; i < vertices.Length; i++)
		{
			colors [i] = Lerp4 (gameColors [0], gameColors [1], gameColors [2], gameColors [3],f);
		}
		mesh.colors32 = colors;
	}

	public Color32 Lerp4(Color32 a, Color32 b, Color32 c, Color32 d, float t)
	{
		if(t<0.33f)
		{
			return Color.Lerp(a,b,t/0.33f);
		}
		else if(t<0.66f)
		{
			return Color.Lerp(b,c,(t-0.33f)/0.33f);
		}
		else 
		{
			return Color.Lerp(c,d,(t-0.66f)/0.66f);
		}
	}


	private void EndGame()
	{
		lose++;
		if (PlayerPrefs.GetInt ("score") < total_score)
		{	
			PlayerPrefs.SetInt ("score", total_score);
		}
		PlayerPrefs.SetInt("lost",prevlose+lose);
		gameOver=true;
		theStack [stackIndex].transform.Rotate (30.0f,0,0);
		theStack [stackIndex].AddComponent<Rigidbody> ();
		endPanel.SetActive (true);

	}
	public void OnButtonClick(string scenename)
	{
        SceneManager.LoadScene(scenename);
	}
}
