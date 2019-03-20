using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
	public float health = 50f;

	public void Damage(float damage){
		health -= damage;
	}

    // Update is called once per frame
    void Update()
    {
		if(health <= 0f){
			Destroy(this.gameObject); //destroy object or do some other behavior
		}
    }
}
