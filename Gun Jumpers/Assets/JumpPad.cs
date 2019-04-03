using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
	public AudioSource woosh;
	public float jumpVelocity = 50f; 

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			other.GetComponent<Rigidbody>().velocity += this.transform.up * jumpVelocity;
			woosh.Play();
		}
	}
}
