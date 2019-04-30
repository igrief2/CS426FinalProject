using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Applies to all single fire guns
public class GunScript : Gun
{
	//[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float bulletVeloc = 30f;
	public float knockbackVeloc = 5f;
	public int ammo = 5;
	public int maxAmmo = 5;
	public float reloadSpeed = 1f; //reloadSpeed second per bullet 
	private float reloadTimer = 0f;
	public float bulletSize = 0f;
	public AudioSource shootSound;
	public AudioSource reloadSound;
	[SerializeField] private Collider playerCol;
	

	public override void reload(){
		reloadTimer += Time.deltaTime;
		if(reloadTimer >= reloadSpeed){
			if(ammo < maxAmmo){
				reloadTimer -= reloadSpeed;
				ammo++;
				reloadSound.Play();
			}
		}
	}

	public override int GetAmmo(){
		return ammo;
	}


    public override System.Tuple<float, Vector3> FireGun()
    {
		if(ammo <= 0){ //if no ammo, nothing should happen  
			return System.Tuple.Create(0f, Vector3.zero);
		}
		shootSound.Play();
		ammo--;
		GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
		newBullet.GetComponent<Transform>().localScale += new Vector3(bulletSize, bulletSize, bulletSize);
		newBullet.GetComponent<Transform>().localPosition += transform.forward; //* (((float)bulletSize * .5f) + 1f); 
		newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;
        // return the knockbackVeloc so can handle the knockback in playerController /* TODO: Fix this so it is not so jumbled */

		Physics.IgnoreCollision(newBullet.GetComponent<Collider>(), playerCol);

        return System.Tuple.Create(knockbackVeloc, transform.forward);
    }
}
