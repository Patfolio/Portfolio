/* TowerUnit.cs
 * Child of Unit, specific information about Tower Units*
 * Author: Dylan Loker, Patrick Pullman
 * */

using UnityEngine;
using System.Collections;

public class TowerUnit : Unit {
	
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		this.speed = 0.0f;
		this.range = 7.0f;
		this.type = Type.TowerUnit;
		this.damage = 20;
		this.attackRate = 1.0f;
		base.GetComponent<Health>().spawnHealth(100);
	}
}
