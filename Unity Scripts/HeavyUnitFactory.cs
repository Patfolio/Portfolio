/* HeavyUnitFactory.cs
 * Factory subclass to create heavy units*
 * Author: Patrick Pullman, Salim Chabou
 * */
using UnityEngine;
using System.Collections;

public class HeavyUnitFactory :  UnitFactory {
	
	public GameObject HeavyUnit;
	
	public void makeUnit(int team, Vector3 spawnPosition){

		this.HeavyUnit.GetComponent<Unit> ().team = team;
		Quaternion spawnRotation = Quaternion.identity;
		GameObject.Instantiate (HeavyUnit, spawnPosition, spawnRotation);

	}
}