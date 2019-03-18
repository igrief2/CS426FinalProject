﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Transform t;
	private Rigidbody rb;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRot = Vector3.zero;
	public float XSensitivity = 20f;
	public float YSensitivity = 20f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;
	public bool lockCursor = true;


	private Quaternion m_GunTargetRot;
	private Quaternion m_HeadTargetRot;
	private bool m_cursorIsLocked = true;
	[SerializeField] private GameObject head;
	[SerializeField] private GameObject gun;

	float curRot = 0f;



    // Start is called before the first frame update
    void Start()
	{	
		m_GunTargetRot = gun.transform.localRotation;
		m_HeadTargetRot = head.transform.localRotation;
		Cursor.visible = false; //hide mouse
		Cursor.lockState = CursorLockMode.Locked; //keep mouse in center of window
		rb = GetComponent<Rigidbody>();
		t = GetComponent<Transform>();    
    }

	void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		LookRotation(); //this part is from the standard assets 
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
		rotation = new Vector3(0f, yRot, 0f) * XSensitivity;
    }

	public void LookRotation()
	{
		float xRot = Input.GetAxisRaw("Mouse Y") * YSensitivity;
		m_GunTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
		m_HeadTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

		if(clampVerticalRotation){
			m_GunTargetRot = ClampRotationAroundXAxis (m_GunTargetRot);
			m_HeadTargetRot = ClampRotationAroundXAxis (m_HeadTargetRot);
		}

		if(smooth)
		{
			gun.transform.localRotation = Quaternion.Slerp (gun.transform.localRotation, m_GunTargetRot,
				smoothTime * Time.deltaTime);
			head.transform.localRotation = Quaternion.Slerp (head.transform.localRotation, m_HeadTargetRot,
				smoothTime * Time.deltaTime);
		}
		else
		{
			gun.transform.localRotation = m_GunTargetRot;
			head.transform.localRotation = m_HeadTargetRot;
		}

		UpdateCursorLock();
	}

	public void SetCursorLock(bool value)
	{
		lockCursor = value;
		if(!lockCursor)
		{//we force unlock the cursor if the user disable the cursor locking helper
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	public void UpdateCursorLock()
	{
		//if the user set "lockCursor" we check & properly lock the cursos
		if (lockCursor)
			InternalLockUpdate();
	}

	private void InternalLockUpdate()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			m_cursorIsLocked = false;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			m_cursorIsLocked = true;
		}

		if (m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (!m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

		angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}
}
