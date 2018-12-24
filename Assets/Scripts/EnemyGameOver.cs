using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGameOver : MonoBehaviour {

	public GameObject target; // should be Player
	public GameObject hand;
	public GameObject throwablePrefab;

	private Animator anim;
	private ThrowableController throwableScript;
	
	void Start(){
		anim = this.GetComponent<Animator>();
		anim.SetTrigger("Attack");
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
		// initiate prefab
		return Instantiate(this.throwablePrefab, hand.transform, false);
	}
}
