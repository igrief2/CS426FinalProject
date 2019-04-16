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
	public int ammo = 10;
	public int maxAmmo = 10;
	public float reloadSpeed = .4f; //reloadSpeed seconds per bullet
	private bool reloading = false;

	public override void reload(){
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

	public override void stopReload(){
		CancelInvoke("reload"); 
	}

	public override System.Tuple<float, Vector3> FireGun()
	{
		if(ammo > 0){ //if no ammo, nothing should happen  
			Invoke("Charging", .2f);
		}
		return System.Tuple.Create(0f, Vector3.zero); 
	}

	private void Charging(){
		
	}

	public override System.Tuple<float, Vector3> EndFire()
	{
		CancelInvoke("Charging");
		return System.Tuple.Create(0f, Vector3.zero); //idk what to return here
	}
}