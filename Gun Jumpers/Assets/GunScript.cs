using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawner;
	public float bulletVeloc = 30;
	public float knockbackVeloc = 30;
    // Start is called before the first frame update
    void Start()
    {
		
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetButtonDown ("Fire1")) {
			GameObject newBullet = GameObject.Instantiate (bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody>().velocity += transform.forward * bulletVeloc;
			player.GetComponent<Rigidbody>().velocity -= transform.forward * knockbackVeloc; 
		}
    }
}
