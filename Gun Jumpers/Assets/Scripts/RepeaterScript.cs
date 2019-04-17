using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The repeater will fire multiple shots when the player holds down the fire button
public class RepeaterScript : Gun
{
	//[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float bulletVeloc = 25;
	public float knockbackVeloc = 3;
	public float rateOfFire = .2f; //rateOfFire seconds per bullet
	public int ammo = 10;
	public int maxAmmo = 10;
	public float bulletSize = -.1f;
	public float reloadSpeed = .4f; //reloadSpeed seconds per bullet
	private bool reloading = false;
	private float curTime = 0f;
	public AudioSource shootSound;
	public AudioSource reloadSound;
	void Start(){
		reset();
	}
	void reset(){
		curTime = 0f;
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
		if(ammo <= 0){ //if no ammo, nothing should happen  
			return System.Tuple.Create(0f, Vector3.zero);
		}
		curTime += Time.deltaTime;
		if(curTime >= rateOfFire){
			shootSound.Play();
			ammo--;
			GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
			newBullet.GetComponent<Transform>().localScale += new Vector3(bulletSize, bulletSize, bulletSize);
			newBullet.GetComponent<Transform>().localPosition += transform.forward * (((float)bulletSize * .5f) + 1f); 
			newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;
			reset();
			return System.Tuple.Create(knockbackVeloc, transform.forward);
		}
		return System.Tuple.Create(0f, Vector3.zero);

	}


}