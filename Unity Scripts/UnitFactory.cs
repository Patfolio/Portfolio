/* UnitFactory.cs
 * Factory interface of factory pattern for unit spawning *
 * Author: Patrick Pullman
 * */
using UnityEngine;
using System.Collections;

public interface UnitFactory {
	
	void makeUnit(int team, Vector3 spawnPosition);

}




