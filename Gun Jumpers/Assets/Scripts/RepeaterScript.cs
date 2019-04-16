using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The repeater will fire multiple shots when the player holds down the fire button
public class RepeaterScript : MonoBehaviour
{
	//[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float bulletVeloc = 30;
	public float knockbackVeloc = 5;

	// Start is called before the first frame update
	void Start()
	{


	}

	// Update is called once per frame
	void Update()
	{
		/*
		if(Input.GetButtonDown ("Fire1")) {
			GameObject newBullet = GameObject.Instantiate (bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;
			//GetComponent<Rigidbody>().velocity -= transform.forward * knockbackVeloc; 
		}
        */
	}

	public System.Tuple<float, Vector3> FireGun()
	{
		GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
		newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;

		// return the knockbackVeloc so can handle the knockback in playerController /* TODO: Fix this so it is not so jumbled */
		return System.Tuple.Create(knockbackVeloc, transform.forward);
	}
}
