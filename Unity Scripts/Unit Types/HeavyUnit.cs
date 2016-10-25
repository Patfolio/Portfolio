/* HeavyUnit.cs
 * Child of Unit, specific information about Heavy Units*
 * Author: Dylan Loker, Patrick Pullman
 * */

using UnityEngine;
using System.Collections;

public class HeavyUnit : Unit {
	
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		this.speed = 2.0f;
		this.range = 8.0f;
		this.type = Type.HeavyUnit;
		this.damage = 10;
		this.attackRate = 2.0f;
		base.GetComponent<Health>().spawnHealth(70);
		Move (this.spawnRally);
	}

}
