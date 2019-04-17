using UnityEngine;
using UnityEngine.Networking;

public class BulletScript : NetworkBehaviour
{
	public float damage = 10f;
	public AudioSource impactSound;
	public bool isImpact = false;
	// Start is called before the first frame update
	void Start()
	{
		Invoke("Despawn", 5); //bullet will disappear in 5 seconds if it hasn't hit anything
	}

	void Update()
	{
		if(isImpact && !impactSound.isPlaying){
			Destroy(this.gameObject);
		}
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
		GetComponent<MeshRenderer>().enabled = false; //make it disappear
		GetComponent<SphereCollider>().enabled = false; //stop it from double hitting
		isImpact = true;
		impactSound.Play();

	}
}
