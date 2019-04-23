using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	public AudioSource hover;
	public AudioSource press;

	public void PlayHover(){
		hover.Play();
	}
	public void PlayPress(){
		press.Play();
	}
}
