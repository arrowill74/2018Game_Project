using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject target; // should be Player
	public GameObject hand;
	public BusinessManController businessManScript; // boyfriend's script
	public List<GameObject> throwablePrefabs = new List<GameObject>();

	private Animator anim;
	private ThrowableController throwableScript;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.businessManScript.alive && !this.businessManScript.onChair) {
			this.anim.SetTrigger("Attack");
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
		return Instantiate(this.throwablePrefabs[randomIndex], hand.transform, true);
	}
}
