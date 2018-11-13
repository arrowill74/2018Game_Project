using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessManController : MonoBehaviour {
    //private variables
    private Vector3 initPos;
    private Quaternion initRot;
    private Animator anim;
    private float health;
    private bool onChair;
    private bool alive;

    //public variables
    public Vector3 onGroundPos; //set the ground position
    public GameObject FollowTarget; //look toward Player
    public CollisionListScript PlayerSensor;
    public GameObject heartParticle;
    public bool isKissing;
    public GameObject girlfriend;

    // Use this for initialization
    void Start() {
        anim = this.GetComponent<Animator>();
        initPos = transform.position;
        initRot = transform.rotation;
        onChair = true;
        alive = true;
        health = 0;
        isKissing = false;
    }

    // Update is called once per frame
    void Update() {
        if(PlayerSensor.target){
            lookAtPlayer();
            lookEachOther();
            if(alive){
                if(onChair){
                    jumpDown();
                }else{
                    if(Input.GetKey(KeyCode.F) && lookEachOther()){
                        anim.SetBool("Hit", true);
                        isKissing = true;
                        health += Time.deltaTime;
                        // Debug.Log("health = " + health);
                        if(health > 5){
                            dead();
                        }
                    }else{
                        anim.SetBool("Hit", false);
                        isKissing = false;
                    }
                }
            }else{
                anim.SetBool("Waving", true);
            }
        }else if(!onChair){
            jumpUp();
        }else{
            anim.SetBool("Waving", false);
            this.gameObject.transform.rotation = initRot;
        }
    }

    bool lookEachOther(){
        FollowTarget = PlayerSensor.target;
        float angle = Quaternion.Angle(this.transform.rotation, FollowTarget.transform.rotation);
        // Debug.Log("Angle = " + angle);
        if(angle > 160){
            return true;
        }else{
            return false;
        }
    }

    void lookAtPlayer(){
        FollowTarget = PlayerSensor.target;
        Vector3 lookAt = FollowTarget.gameObject.transform.position;
        lookAt.y = this.gameObject.transform.position.y;
        this.transform.LookAt(lookAt);
    }
    void jumpDown() {
        // anim.SetTrigger("Jump");
        this.gameObject.transform.position = onGroundPos;
        onChair = false;
    }

    void jumpUp() {
        anim.SetTrigger("BackToSeat");
        // anim.SetTrigger("Jump");
        this.gameObject.transform.position = initPos;
        this.gameObject.transform.rotation = initRot;
        onChair = true;
    }

    void dead() {
        anim.SetBool("Hit", false);
        isKissing = false;
        anim.SetTrigger("Dead");
        heartParticle.SetActive(true);
        alive = false;
    }
}