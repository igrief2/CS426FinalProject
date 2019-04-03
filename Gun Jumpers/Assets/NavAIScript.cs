using UnityEngine;
using UnityEngine.AI;


public class NavAIScript : MonoBehaviour
{

	NavMeshAgent agent;
	public Vector3 target;

	public float xMin = -38f;
	public float xMax = 28f;
	public float zMin = -60f;
	public float zMax = 9f; 

	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		setTarget();
    }

    // Update is called once per frame
    void Update()
    {
		agent.SetDestination(target);
    }

	void setTarget(){
		//just choose values between min and max
		float xVal = Random.Range(xMin, xMax);
		float zVal = Random.Range(zMin, zMax);
		target = new Vector3(xVal, 0, zVal);
		Invoke("setTarget", 10); //call setTarget again in 10 seconds
		animator.SetBool("Moving", true);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			animator.SetBool("Moving", false);
			agent.Stop();
			CancelInvoke();
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			animator.SetBool("Moving", true);
			agent.ResetPath(); //continue on path
			Invoke("setTarget", 10);
		}
	}

}
