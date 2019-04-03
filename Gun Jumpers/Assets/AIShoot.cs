using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
	public AudioSource shoot;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	[SerializeField] private GameObject barrel;
	public float bulletVeloc = 30;

	void OnEnable(){
		Invoke("ShootBullet", .5f); //calls shootBullet in .5 seconds
	}

	private void ShootBullet(){
		GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawner.transform.position, barrel.transform.rotation) as GameObject;
		newBullet.GetComponent<Rigidbody>().velocity -= barrel.transform.up * bulletVeloc;
		Invoke("ShootBullet", .5f); //calls shootBullet in .5 seconds
		shoot.Play();
	}

	void OnDisable(){
		CancelInvoke();
	}
}