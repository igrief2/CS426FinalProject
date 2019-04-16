using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public float damage = 10f;
	// Start is called before the first frame update
	void Start()
	{
		Invoke("Despawn", 5); //bullet will disappear in 5 seconds if it hasn't hit anything
	}

	void OnCollisionEnter(Collision collision){
		/*
		Collider collider = collision.collider;
		if(collider.tag == this.tag) { //im thinking the tags should be "team 1" and "team 2" or something
			var damageable = collider.gameObject.GetComponent<Damageable>(); //check if damageable object (players) 
			if(damageable){
				damageable.Damage(damage);
			}
		}
		*/

		Despawn();
	}


	//despawn
	void Despawn(){
		Destroy(this.gameObject);
	}
}
