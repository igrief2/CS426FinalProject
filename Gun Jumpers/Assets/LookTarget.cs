using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{

	public Transform target = null; //object to look at
	public Transform source; //object doing the looking
	public float addRotX = -84;
	public float addRotY = 0;
	public float addRotZ = -8;
	public float smooth = 50; //smoothing value makes the slerp happen a lot more responsively 
	public Transform neutralPosition;

    // Update is called once per frame
    void Update()
    {
		//for some reason doing this using transform.LookAt and transform.rotation didn't work well, it would keep jittering
		if(target != null){
			Vector3 relativePos = target.position - source.position; 
			Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up); //this gets us the rotation we'd get from using transform.LookAt
			rotation *= Quaternion.Euler(addRotX, addRotY, addRotZ); //this adds this rotation to the curent rotation, gets us looking at our object
			source.rotation = Quaternion.Slerp(source.rotation, rotation, Time.deltaTime * smooth); //go from transform.rotation to rotation
		}
    }

	void OnDisable(){ //should reset rotation when script is disabled
		Vector3 relativePos = neutralPosition.position - source.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up); //should point at 0
		rotation *= Quaternion.Euler(addRotX, addRotY, addRotZ); //this adds this rotation to the curent rotation, gets us looking at our object
		source.rotation = Quaternion.Slerp(source.rotation, rotation, smooth);

		Debug.Log("lookTarget disabled");
	}
}
