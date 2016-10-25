/* BaseUnit.cs
 * Child of Unit, specific information about Bases
 * Author: Dylan Loker
 * */

using UnityEngine;
using System.Collections;

public class BaseUnit : Unit {
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		this.speed = 0.0f;
		this.range = 0.0f;
		this.type = Type.Base;
		this.damage = 0;
		this.attackRate = 0.0f;
		base.GetComponent<Health>().spawnHealth(200);
	}
}
