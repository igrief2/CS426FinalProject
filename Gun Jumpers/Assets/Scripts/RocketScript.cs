using UnityEngine;
using UnityEngine.Networking;

public class RocketScript : NetworkBehaviour
{

	public float radius = 5f;
	public float force = 50000f;
	public float upwardsModifier = 0f;
	public ForceMode forceMode = ForceMode.Force;
	public AudioSource explosionSound;
	public ParticleSystem ps; 
	private bool isExploded = false;

    // Start is called before the first frame update
    void Start()
    {
		Invoke("Explode", 5); //rocket will explode in 5 seconds if it hasn't hit anything
    }

    // Update is called once per frame
    void Update()
    {
		if(isExploded && !explosionSound.isPlaying){
			Destroy(this.gameObject);
		}
    }

	void OnCollisionEnter(Collision col){

        //Debug.Log("Player hit: " + col.gameObject.name);
        
		CancelInvoke("Explode");
		Explode();
	}


	//Boom
	void Explode(){
		GetComponent<MeshRenderer>().enabled = false; //make it disappear
		GetComponent<CapsuleCollider>().enabled = false; //so it doesnt double hit 
		GetComponent<Rigidbody>().isKinematic = true; //stops it from rotating
		explosionSound.Play();
		ps.Play();
		Debug.Log("Explode method");
		foreach(Collider collider in Physics.OverlapSphere(transform.position, radius)){ //from PushyPixels' Breakfast With Unity youtube series
			if(collider.tag == "Player"){
				RaycastHit hit;
				if(Physics.Raycast(transform.position, collider.transform.position - transform.position, out hit, Mathf.Infinity)){ //prevent from going through walls
					if(hit.collider == collider) {
						collider.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, upwardsModifier, forceMode); //add force to player rb
						Debug.Log("should be hit: " + collider.name);
					}
				}
			}
		}
		isExploded = true;
	}
}
