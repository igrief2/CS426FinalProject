using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretActivator : MonoBehaviour
{

	private Animator animator;

	void Awake(){
		animator = GetComponent <Animator>();
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("firing is true");
			animator.SetBool ("Firing", true);
			GetComponent<AIShoot>().enabled = true; //turn on AIShoot script
			LookTarget look = GetComponent<LookTarget>(); //get lookTarget script
			look.enabled = true; //turn on LookTarget script
			look.target = other.gameObject.transform; //set lookTarget target

		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("firing is false");
			animator.SetBool ("Firing", false);
			GetComponent<LookTarget>().enabled = false; //turn off LookTarget script
			GetComponent<AIShoot>().enabled = false; //turn off AIShoot script
		}
	}
}
