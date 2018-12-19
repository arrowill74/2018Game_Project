using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	// Use this for initialization
	/*
	 */
	void Start () {
		Destroy(gameObject, 5);
		//銷毀(要銷毀的物件,幾秒後銷毀);
		
	}
	
	void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player"){
            // Debug.Log("get gift");
            Destroy(gameObject);
            
        }
        	
    }
}
