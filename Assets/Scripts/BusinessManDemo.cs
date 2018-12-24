using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessManDemo : MonoBehaviour {
	private float health;
    private AudioSource loveSong;
	private Animator anim;
    
    //public variables
    public GameObject heartParticle;
    public bool isKissing {get; private set;}
    public bool alive {get; private set;}

    public Slider healthBar;
    public GameObject healthBarUI;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
        loveSong = this.GetComponent<AudioSource>();
	}

	void OnEnable () {
        alive = true;
        health = 0;
	}

	void OnDisable () {
		heartParticle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = CalculateHealth();
		if(alive){
			if(Input.GetKey(KeyCode.Space)){
				anim.SetBool("Hit", true);
				health += Time.deltaTime;
				// Debug.Log("health = " + health);
				if(health > 5){
					dead();
					loveSong.Play();
				}
			}else{
				anim.SetBool("Hit", false);
			}
		}else{
			anim.SetBool("Waving", true);
		}
    }

    float CalculateHealth(){
        return health/5;
    }

	void dead() {
        Destroy(healthBarUI);
        anim.SetBool("Hit", false);
        isKissing = false;
        anim.SetTrigger("Dead");
        heartParticle.SetActive(true);
        alive = false;
    }
	
}
