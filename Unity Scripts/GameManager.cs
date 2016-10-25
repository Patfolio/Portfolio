/* GameManager.cs
 * Controls Unit spawning *
 * Author: Salim Chabou, Patrick Pullman,Dylan Loker
 * */

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public Vector3 redLightSpawnLocation;
	public Vector3 redHeavySpawnLocation;

	public Vector3 blueLightSpawnLocation;
	public Vector3 blueHeavySpawnLocation;
	//public GameObject Game

	private LightUnitFactory LightFactory = new LightUnitFactory ();
	private HeavyUnitFactory HeavyFactory = new HeavyUnitFactory ();

	public GameObject LightUnit;
	public GameObject HeavyUnit;

	private bool gameOver;
	private bool isPause = false;
	private Rect pauseRect = new Rect(20,20,128,128);

	private GUISkin guiSkin;
	private Rect MainMenu = new Rect(10, 10, 200, 200);

	void OnGUI(){
		pauseRect = GUI.Window (0,pauseRect,PauseButton,"");
	}
	
	void PauseButton(int windowID){
		if (GUI.Button(new Rect(0,0,128,128),"P")){
			Time.timeScale = (Time.timeScale+1)%2;
			isPause = !isPause;
			if (isPause){
				Debug.Log ("Paused!");
			}
			else{
				Debug.Log ("Unpaused!");
			}
		}
	}
	
	void Start ()
	{
		gameOver = false;
		LightFactory.LightUnit = LightUnit;
		HeavyFactory.HeavyUnit = HeavyUnit;
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (2);
		while (!gameOver)
		{
			LightFactory.makeUnit(1,blueLightSpawnLocation);
			HeavyFactory.makeUnit(1,blueHeavySpawnLocation);

			LightFactory.makeUnit(0,redLightSpawnLocation);
			HeavyFactory.makeUnit(0,redHeavySpawnLocation);

		    yield return new WaitForSeconds (20);

		}
	}
	
	void Update()
	{
		if( Input.GetKeyDown(KeyCode.Escape)){
			isPause = !isPause;
			if(isPause)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}

		if (GameObject.Find("enemybase") == null && !gameOver){ // player win
			//Debug.Log ("player wins");
			Application.LoadLevel("playerwin");
			gameOver = true;
			
		}
		else if (GameObject.Find("base") == null && !gameOver){
			//Debug.Log ("enemy wins");
			Application.LoadLevel("playerlose");
			gameOver = true;
		}
	}
}
