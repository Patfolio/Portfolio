/* CapturePoint.cs
 * Implements mechanics of the capture points in game*
 * Author: Patrick Pullman
 * */
using UnityEngine;
using System.Collections;

public class CapturePoint : MonoBehaviour {

	public int allegiance;
	private int state;
	private int PlayerUnitCounter;
	private int EnemyUnitCounter;
	public int allegianceScale;

	public Vector3 RedTowerPosition;
	public Vector3 BlueTowerPosition;

	private TowerUnitFactory TowerFactory = new TowerUnitFactory ();

	public GameObject tower;

	// Use this for initialization
	void Start () {
		allegiance = 0;
		allegianceScale = 0;
		PlayerUnitCounter = 0;
		TowerFactory.TowerUnit = tower;
	}
	
	// Update is called once per frame
	void Update () {

		if (allegiance == 0) {
			switch (state) {
			case 0:
				renderer.material.color = Color.grey;
				break;
			case 1:
				renderer.material.color = Color.magenta;

				if (allegianceScale < 500) {
					allegianceScale++;
				}
				break;
			case 2:
				renderer.material.color = Color.cyan;
					
				if (allegianceScale > -500) {
					allegianceScale--;
				}
				break;
			case 3:
				renderer.material.color = Color.yellow;
				break;
			default:
				renderer.material.color = Color.grey;
				break;
			}
			if (allegianceScale >= 500) {
				allegiance = 1;
				renderer.material.color = Color.red;
				spawnTowers(0,RedTowerPosition);

			} else if (allegianceScale <= -500) {
				allegiance = 2;
				renderer.material.color = Color.blue;
				spawnTowers(1,BlueTowerPosition);
			}
		} else if (allegiance == 1) {
			switch (state) {
			case 0:
				renderer.material.color = Color.red;
				break;
			case 1:
				if (allegianceScale < 500) {
					allegianceScale++;
				}
				break;
			case 2:
				renderer.material.color = Color.yellow;
				if (allegianceScale > 0) {
					allegianceScale--;
				} else {
					allegiance = 0;
				}
				break;
			case 3:
				renderer.material.color = Color.red;
				break;
			default:
				renderer.material.color = Color.grey;
				break;
			}

		} else {
			switch(state){
			case 0:
				renderer.material.color = Color.blue;
				break;
			case 1:
				renderer.material.color = Color.yellow;
				if (allegianceScale < 0) 
					allegianceScale++;
				else 
					allegiance = 0;
				break;
			case 2:
				if (allegianceScale > -500) 
					allegianceScale--;
				break;
			case 3:
				renderer.material.color = Color.blue;
				break;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Unit UnitEntering = other.gameObject.GetComponent<Unit>();

		if (UnitEntering.team == 0) {
			PlayerUnitCounter++;
			if (state == 0) {
				state = 1;
			}else if (state == 2){
				state = 3;
			}
		} else {
			EnemyUnitCounter++;
			if (state == 0) {
				state = 2;
			}else if (state == 1){
				state = 3;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		Unit UnitExiting = other.gameObject.GetComponent<Unit> ();
		if (UnitExiting.team == 0) {
			PlayerUnitCounter--;
		} else {
			EnemyUnitCounter--;
		}
		if (PlayerUnitCounter == 0 && EnemyUnitCounter == 0) {
			state = 0;
		}
		if (state == 3 && PlayerUnitCounter == 0) {
			state = 2;
		}
		if (state == 3 && EnemyUnitCounter == 0) {
			state = 1;
		}
	}

	void spawnTowers(int team, Vector3 towerposition){
		this.TowerFactory.makeUnit (team,towerposition);
	}

	void DestroyTowers(){

	}
}
