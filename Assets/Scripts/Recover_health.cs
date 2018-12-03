using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Recover_health : MonoBehaviour {
	public Life LifeScript;
    public AudioClip impact;
    AudioSource audiosource;

    

	// Use this for initialization
    void Start(){
        audiosource = GetComponent<AudioSource>();
    }
	void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "gift"){
            this.LifeScript.img.fillAmount += 0.05f; //加血
            audiosource.PlayOneShot(impact);
        }
        	
    }
}
