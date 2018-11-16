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
	
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		// businessManScript = boyfriend.GetComponent<BusinessManController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (businessManScript.alive && !this.businessManScript.onChair) {
			this.anim.SetTrigger("Attack");
		}
		if (Vector3.Distance(target.transform.position, boyfriend.transform.position) < 5.0f)
        {
            agent.SetDestination(target.transform.position);
        }
            
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
