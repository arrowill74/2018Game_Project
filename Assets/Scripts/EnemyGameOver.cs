using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGameOver : MonoBehaviour {

	public GameObject target; // should be Player
	public GameObject hand;
	// public GameObject boyfriend;
	public List<GameObject> throwablePrefabs = new List<GameObject>();
	// public BusinessManController businessManScript;

    private NavMeshAgent agent;
	private Animator anim;
	private ThrowableController throwableScript;
	private Vector3 pos;
	

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
