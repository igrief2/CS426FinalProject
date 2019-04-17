using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//okay yeah so this whole abstract gun class thing is terrible but it was the only thing i could think of at 2 am that worked 
//basically every gun will override all of these methods so that they can be used in playercontroller
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
	public virtual int GetAmmo(){
		return 0;
	}

}
