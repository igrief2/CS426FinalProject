using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Transform t;
	private Rigidbody rb;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRot = Vector3.zero;
	private float mouseSensitivity = 3f;
	[SerializeField] private GameObject head;
	[SerializeField] private GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
		Cursor.visible = false; //hide mouse
		Cursor.lockState = CursorLockMode.Locked; //keep mouse in center of window
		rb = GetComponent<Rigidbody>();
		t = GetComponent<Transform>();    
    }

	void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		head.transform.Rotate(-cameraRot);
		gun.transform.Rotate(-cameraRot);
	}	

	//FixedUpdate is called every physics iteration
	void FixedUpdate(){
		PerformRotation();
	}

    // Update is called once per frame
    void Update()
    {



		//calculating rotation via mouse input
		//from Brackeys video
		float yRot = Input.GetAxisRaw("Mouse X");
		rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;

		float xRot = Input.GetAxisRaw("Mouse Y");
		float newRot = xRot * mouseSensitivity;

		//Quaternions only deal with 0-360 so we have to limit from 0-90 and then from 270-360 to get the proper range of movement
		float curXRot = head.transform.localRotation.eulerAngles.x + newRot;

		if((curXRot >= 0 && curXRot < 90) || (curXRot > 270 && curXRot <= 360)){
			//Debug.Log(curXRot);
			cameraRot = new Vector3(newRot, 0f, 0f); 
		}
    }
}
