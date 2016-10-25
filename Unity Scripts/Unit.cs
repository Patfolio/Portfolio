/* Unit.cs
 * Stores basic information about game Units*
 * Author: Salim Chabou, Dylan Loker, Patrick Pullman
 * */

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	public int team;
	public bool selected;
	public enum Type: byte {LightUnit, HeavyUnit, TowerUnit, Base};

	protected float speed = 0.0f;
	public Unit target = null;
	public State state;
	public Color teamColour;
	protected Type type;
	protected float range;
	protected int damage;
	protected float attackRate;
	public Transform attackObj;
	private float cooldown;
	private Vector3 destination;
	protected Vector3 spawnRally;
	
	/* method for looking at a world coordinate, ignoring y-axis (2D) */
	public void lookAtPos(Vector3 pos){
		Vector3 a = pos;
		Vector3 b = this.transform.position;
		// flattens position to y=0 plane, making every "look" in 2D
		a.y = 0;
		b.y = 0;
		
		this.transform.rotation = Quaternion.LookRotation(a-b, new Vector3(0,100,0));
	}
	/******************/
	
	/* helper method for drawing lines */
	/* taken from http://www.everyday3d.com/blog/index.php/2010/03/15/3-ways-to-draw-3d-lines-in-unity3d/ */
	public void drawAttack(Unit a, Unit b, Color col){
		Vector3 mid = a.transform.position + (b.transform.position - a.transform.position)/2;
		Quaternion rot = Quaternion.LookRotation(b.transform.position - a.transform.position);
		Transform projectile = (Transform)Instantiate(attackObj,mid,rot);
		projectile.GetComponent<Attack_Temp>().setColor(this.teamColour);
	}
	
	public void changeState(State newState){
		this.state = newState;
	}

	// getters
	public Type getUnitType(){
		return this.type;
	}
	
	public float getRange(){
		return this.range;
	}
	
	public int getDamage(){
		return this.damage;
	}
	
	public float getAttackRate(){
		return this.attackRate;
	}
	
	public float getSpeed(){
		return this.speed;
	}
	
	public bool canFire(){
		return (this.cooldown <= 0.0f);
	}
	
	public Vector3 getDestination(){
		return this.destination;
	}
	
	public Unit getTarget(){
		return this.target;
	}

	// setters
	public void resetCooldown(){
		this.cooldown = this.attackRate;
	}
	
	public void setDestination(Vector3 dest){
		this.destination = dest;
	}
	
	public void setTarget(Unit target){
		this.target = target;
	}
	
	//Public function for move command
	public void Move(Vector3 location){
		if (this is LightUnit || this is HeavyUnit){
			this.GetComponent<NavMeshAgent>().updatePosition = true;
			this.setTarget (null);
			this.setDestination(Vector3.zero);
			if(location != Vector3.zero) {
				this.GetComponent<NavMeshAgent>().destination = location;
				this.setDestination(location);
			}
			this.changeState(new Moving());
		}
	}
	
	//Public function for attack, called if player right clicks enemy unit
	public void Attack(Unit target){
		if (this is LightUnit || this is HeavyUnit){
			this.target = target;
			this.setDestination(Vector3.zero);
			if(target.transform.position != Vector3.zero) {
				this.GetComponent<NavMeshAgent>().destination = target.transform.position;
				this.setDestination(target.transform.position);
			}
			this.changeState(new Attacking());
		}
	}
	
	protected virtual void Start(){
		if(this is LightUnit || this is HeavyUnit)
			this.GetComponent<NavMeshAgent>().stoppingDistance = 2.0f;

		this.state = new Idle();
		spawnRally = transform.position;
 
		switch (team) {
			case 0:
					renderer.material.color = Color.red;
					teamColour = Color.red;
					spawnRally.x+=2;
					spawnRally.z-=2;
					break;
			case 1:
					renderer.material.color = Color.blue;
					teamColour = Color.blue;
					spawnRally.x-=2;
					spawnRally.z+=2;
					break;
			default:
					break;
		}
		this.cooldown = 0.0f;

	}
	
	void Update () {
		Behaviour h = (Behaviour)GetComponent("Halo");
		if (selected)
			h.enabled = true;
		else{
			h.enabled = false;
		}
		if (state != null)
			state.Update(this);
		// cooldown reduction
		if (!this.canFire()){
			this.cooldown -= Time.deltaTime;
		}

	}

	/*void OnTriggerEnter(Collider other) {
		Debug.Log ("Collision");
		Unit UnitEntering = other.gameObject.GetComponent<Unit> ();
		if (UnitEntering == null) {
			return;
		} else if (UnitEntering.state is Idle) {
			Debug.Log ("is Idle");
			this.GetComponent<NavMeshAgent>().destination = this.transform.position;
			this.state = new Idle();
		}
	}*/
	
}