using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableController : MonoBehaviour {

	// public GameObject hand;
	public int throwForceY = 350;
	public int throwForceZ = 700;
	private Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = this.gameObject.GetComponent<Rigidbody>();
		rigid.isKinematic = true;
	}

	public void releaseItem() {
		rigid.isKinematic = false;
		this.transform.parent = null;
		rigid.AddForce(this.transform.up * this.throwForceY);
		rigid.AddForce(this.transform.forward * this.throwForceZ);
	}
}
