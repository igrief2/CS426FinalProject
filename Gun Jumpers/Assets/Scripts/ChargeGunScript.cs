using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Applies to all single fire guns
public class ChargeGunScript : Gun
{
	//[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float rateOfCharge = .1f; //how many seconds until next charge increment 
	public float chargeIncrement = .01f; //how large a charge increment is (1 is 100%)
	public float maxSize = .5f;
	public float minSize = 0f;
	public float maxDamage = 50f;
	public float minDamage = 10f;
	public float minBulletVeloc = 10f;
	public float maxBulletVeloc = 15f;
	public float minKnockbackVeloc = 5f;
	public float maxKnockbackVeloc = 15f;
	private float knockbackVeloc;
	private float bulletVeloc;
	private float damage;
	private float bulletSize;
	public int ammo = 100;
	public int maxAmmo = 100;
	public float reloadSpeed = .3f; //reloadSpeed seconds per bullet
	private bool reloading = false;
	private float currentPercent = 0f;
	public AudioSource chargeSound;
	public AudioSource shootSound;
	public AudioSource reloadSound;

	// Start is called before the first frame update
	void Start()
	{
		reset();
	}

	void reset(){
		knockbackVeloc = minKnockbackVeloc;
		bulletVeloc = minBulletVeloc;
		damage = minDamage;
		bulletSize = minSize;
		currentPercent = 0f;
	}

	public override void reload(){
		Debug.Log("reload method. ammo = " + ammo);
		if(reloading){ //honestly this is just so it waits for a bit before reloading the first time
			if(ammo < maxAmmo){
				ammo++;
				reloadSound.Play();
			}
		}
		else{
			reloading = true;
		}
		Invoke("reload", reloadSpeed); //invoke reload after the reloadSpeed 
	}

	public override void stopReload(){
		CancelInvoke("reload"); 
	}
		
	public override int GetAmmo(){
		return ammo;
	}


	public override System.Tuple<float, Vector3> FireGun()
	{
		Debug.Log("charge firegun");
		if(ammo > 0){ 
			chargeSound.Play();
			Invoke("Charging", rateOfCharge);
		}
		return System.Tuple.Create(0f, Vector3.zero); 
	}

	private void Charging(){
		Debug.Log("charge Charging");

		if(ammo > 0) { //only do anything if we have ammo
			if(currentPercent < 1){ //when its at full charge, don't use any more ammo, don't charge any more
				currentPercent += chargeIncrement;
				if(currentPercent >= 1)
					currentPercent = 1;
				knockbackVeloc = Mathf.Lerp(minKnockbackVeloc, maxKnockbackVeloc, currentPercent);
				bulletVeloc = Mathf.Lerp(minBulletVeloc, maxBulletVeloc, currentPercent);
				damage = Mathf.Lerp(minDamage, maxDamage, currentPercent);
				bulletSize = Mathf.Lerp(minSize, maxSize, currentPercent);
				ammo--;
			}
		}
		Invoke("Charging", rateOfCharge);
	}

	public override System.Tuple<float, Vector3> EndFire()
	{
		Debug.Log("charge Endfire");

		CancelInvoke("Charging");
		if(currentPercent <= 0){ //if currentPercent is 0 then nothing should happen, its 0% charged
			reset();
			return System.Tuple.Create(0f, Vector3.zero);
		}
		shootSound.Play();
		GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
		newBullet.GetComponent<Transform>().localScale += new Vector3(bulletSize, bulletSize, bulletSize);
		newBullet.GetComponent<Transform>().localPosition += transform.forward * (((float)bulletSize * .5f) + 1f); 
		newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;
		// return the knockbackVeloc so can handle the knockback in playerController /* TODO: Fix this so it is not so jumbled */

		//MODIFY DAMAGE
		newBullet.GetComponent<BulletScript>().damage = damage;
		float kbv = knockbackVeloc;//store knockback
		reset();
		return System.Tuple.Create(kbv, transform.forward);
	}
}
