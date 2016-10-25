/* LightUnit.cs
 * Child of Unit, specific information about Light Units*
 * Author: Dylan Loker, Patrick Pullman
 * */

using UnityEngine;
using System.Collections;

public class LightUnit : Unit {
	
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		this.speed = 4.0f;
		this.range = 4.0f;
		this.type = Type.LightUnit;
		this.damage = 5;
		this.attackRate = 0.5f;
		base.GetComponent<Health>().spawnHealth(50);
		Move (this.spawnRally);
	}
}
