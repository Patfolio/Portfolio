/* CapturePoint.cs
 * Factory for creating Tower Units*
 * Author: Patrick Pullman
 * */

using UnityEngine;
using System.Collections;

public class TowerUnitFactory : UnitFactory {

	public GameObject TowerUnit;
	
	public void makeUnit(int team, Vector3 spawnPosition){
		
		this.TowerUnit.GetComponent<Unit> ().team = team;
		
		Quaternion spawnRotation = Quaternion.identity;
		GameObject.Instantiate (TowerUnit, spawnPosition, spawnRotation);
		
	}
}
