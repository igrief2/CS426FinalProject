using UnityEngine;

public class RocketScript : MonoBehaviour
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
		Explode();
	}


	//Boom
	void Explode(){
		Destroy(this.gameObject);
	}
}
