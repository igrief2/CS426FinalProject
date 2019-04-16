using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Applies to all single fire guns
public class GunScript : MonoBehaviour
{
	//[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float bulletVeloc = 30f;
	public float knockbackVeloc = 5f;
	public int ammo = 5;
	public int maxAmmo = 5;
	public float reloadSpeed = 1f; //1f second per bullet 
	private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
		
        
    }

	public void reload(){
		Debug.Log("reload method. ammo = " + ammo);
		if(reloading){ //honestly this is just so it waits for a bit before reloading the first time
			if(ammo < maxAmmo){
				ammo++;
			}
		}
		else{
			reloading = true;
		}
		Invoke("reload", reloadSpeed); //invoke reload after the reloadSpeed 
	}

	public void stopReload(){
		CancelInvoke("reload"); 
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
		if(ammo <= 0){ //if no ammo, nothing should happen  
			return System.Tuple.Create(0f, Vector3.zero);
		}
		ammo--;
		GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
		newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;
        // return the knockbackVeloc so can handle the knockback in playerController /* TODO: Fix this so it is not so jumbled */
        return System.Tuple.Create(knockbackVeloc, transform.forward);
    }
}
