using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGameOver : MonoBehaviour {

	public GameObject target; // should be Player
	public GameObject hand;
	// public GameObject boyfriend;
	public GameObject throwablePrefab;
	// public BusinessManController businessManScript;

    private NavMeshAgent agent;
	private Animator anim;
	private ThrowableController throwableScript;
	private Vector3 pos;
	
	void Start(){
		throwableScript = this.throwablePrefab.GetComponent<ThrowableController>();
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
		// int randomIndex = Random.Range(0, this.throwablePrefab.Count);
		return Instantiate(this.throwablePrefab, hand.transform, false);
	}
}
