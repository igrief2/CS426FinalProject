using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
	public AudioSource woosh;
	public float jumpVelocity = 50f; 

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.velocity += this.transform.up * jumpVelocity;
			woosh.Play();
		}
	}
}
