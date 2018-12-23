using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDemo : MonoBehaviour {

	public GameObject target; // should be Player
	public GameObject hand;
	// public GameObject boyfriend;
	public List<GameObject> throwablePrefabs = new List<GameObject>();
	// public BusinessManController businessManScript;

    private NavMeshAgent agent;
	private Animator anim;
	private ThrowableController throwableScript;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}
	void OnEnable(){
		this.transform.position = new Vector3(-13.731f, 0.02f, 9.6f);
		
	}
	// Update is called once per frame
	void Update () {
		pos = this.transform.position; 
		// if (businessManScript.alive && !this.businessManScript.onChair) {
            agent.SetDestination(target.transform.position);
			this.anim.SetBool("Walk", true);
			if(Vector3.Distance(target.transform.position, pos)<3f){
				this.anim.SetBool("Walk", false);
				this.anim.SetTrigger("Attack");
			}
        // }
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
