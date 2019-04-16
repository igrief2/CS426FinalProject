using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Applies to all single fire guns
public class ChargeGunScript : MonoBehaviour
{
	//[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float rateOfCharge = 1f; 
	public float maxSize = 5f;
	public float minSize = .1f;
	public float maxDamage = 50f;
	public float minDamage = 10f;
	public float minBulletVeloc = 10f;
	public float maxBulletVeloc = 15f;
	public float minKnockbackVeloc = 5f;
	public float maxKnockbackVeloc = 15f;
	public float knockbackVeloc;
	public float bulletVeloc;
	public float damage;
	public float size;
	// Start is called before the first frame update
	void Start()
	{
		knockbackVeloc = minKnockbackVeloc;
		bulletVeloc = minBulletVeloc;
		damage = minDamage;
		size = minSize;

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
