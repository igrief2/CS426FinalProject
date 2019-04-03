using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsActivator : MonoBehaviour
{

	public Animator[] lights;
    // Start is called before the first frame update
    void Start()
    {
        //call main loop
		AnimLoop();
    }

	void AnimLoop(){
		foreach (var light in lights) {
			light.SetInteger ("State", RandomInt()); //sets state to a random int
		}
		Invoke("AnimLoop", 3); //calls the loop again in 3 seconds
	}

	int RandomInt(){
		return Random.Range(0,4); //returns random int between 0 and 3 inclusive
	}
}
