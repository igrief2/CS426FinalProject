using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Gun : MonoBehaviour
{
	public virtual void reload(){}
	public virtual void stopReload(){}
	public virtual System.Tuple<float, Vector3> FireGun(){
		return System.Tuple.Create(0f, Vector3.zero); //this will be overwritten
	}
	public virtual System.Tuple<float, Vector3> EndFire(){
		return System.Tuple.Create(0f, Vector3.zero); //this will also be overwritten
	}
}
