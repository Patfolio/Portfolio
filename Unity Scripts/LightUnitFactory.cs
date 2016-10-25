/* LightUnitFactory.cs
 * Factory subclass to create light units*
 * Author: Patrick Pullman, Salim Chabou
 * */

using UnityEngine;
using System.Collections;

public class LightUnitFactory : UnitFactory  {
		
	public GameObject LightUnit;
		
	public void makeUnit(int team, Vector3 spawnPosition){
			
		this.LightUnit.GetComponent<Unit> ().team = team;

		Quaternion spawnRotation = Quaternion.identity;
		GameObject.Instantiate (LightUnit, spawnPosition, spawnRotation);

	}
}
