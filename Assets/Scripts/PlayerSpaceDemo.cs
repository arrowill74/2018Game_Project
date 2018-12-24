using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceDemo : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
            anim.SetBool("hit", true);
        }else{
            anim.SetBool("hit", false);
        }
	}
}
