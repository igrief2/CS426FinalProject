using UnityEngine;
using UnityEngine.Networking;

public class RocketScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Invoke("Explode", 5); //rocket will explode in 5 seconds if it hasn't hit anything
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision col){

        //Debug.Log("Player hit: " + col.gameObject.name);
        
		Explode();
	}


	//Boom
	void Explode(){
		Destroy(this.gameObject);
	}
}
