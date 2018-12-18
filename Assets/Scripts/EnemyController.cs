using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public GameObject target; // should be Player
	public GameObject hand;
	public GameObject boyfriend;
	public List<GameObject> throwablePrefabs = new List<GameObject>();
	public BusinessManController businessManScript;

    private NavMeshAgent agent;
	private Animator anim;
	private ThrowableController throwableScript;
	private Vector3 pos;
	private float wanderRadius;
    private float wanderTimer;
    private float timer;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		wanderRadius = 20;
		wanderTimer = 10;
	}
	
	// Update is called once per frame
	void Update () {
		pos = this.transform.position; 
		if (businessManScript.alive && !this.businessManScript.onChair) {
            agent.SetDestination(target.transform.position);
			this.anim.SetBool("Walk", true);
			if(Vector3.Distance(target.transform.position, pos)<3f){
				this.anim.SetBool("Walk", false);
				this.anim.SetTrigger("Attack");
			}
        }else{
			timer += Time.deltaTime;
			if (timer >= wanderTimer) {
				Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				agent.SetDestination(newPos);		
				timer = 1;
			}
			bool moving = agent.remainingDistance > agent.stoppingDistance;
			this.anim.SetBool("Walk", moving);
		}
	}
	
	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

	void throwItem () {
		// Turn to target's direction then throw
		this.gameObject.transform.LookAt(target.transform);
		throwableScript.releaseItem();
	}

	void getThrowableScript() {
		GameObject throwableItem = this.initiateThrowableItem();
		this.throwableScript = throwableItem.GetComponent<ThrowableController>();
	}

	GameObject initiateThrowableItem() {
		// randomly select a prefab to initiate
		int randomIndex = Random.Range(0, this.throwablePrefabs.Count);
		return Instantiate(this.throwablePrefabs[randomIndex], hand.transform, false);
	}
}
