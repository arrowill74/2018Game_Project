using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BusinessManController : MonoBehaviour {
    //private variables
    private Vector3 initPos;
    private Quaternion initRot;
    private Animator anim;
    private float health;
    private AudioSource loveSong;
    private NavMeshAgent agent;

    //public variables
    public Vector3 onGroundPos; //set the ground position
    public GameObject FollowTarget; //look toward Player
    public CollisionListScript PlayerSensor;
    public GameObject heartParticle;
    public GameObject chair;
    public bool isKissing {get; private set;}
    public bool alive {get; private set;}
    public bool onChair {get; private set;}
    public Slider healthBar;
    public GameObject healthBarUI;

    // Use this for initialization
    void Start() {
        anim = this.GetComponent<Animator>();
        loveSong = this.GetComponent<AudioSource>();
        agent = this.GetComponent<NavMeshAgent>();
        initPos = transform.position;
        initRot = transform.rotation;
        onChair = true;
        alive = true;
        health = 0;
        isKissing = false;
    }

    // Update is called once per frame
    void Update() {
        healthBar.value = CalculateHealth();
        if(PlayerSensor.target){
            lookAtPlayer();
            lookEachOther();
            if(alive){
                if(onChair){
                    jumpDown();
                    agent.enabled = true;
                }else{
                    if(Input.GetKey(KeyCode.Space) && lookEachOther()){
                        anim.SetBool("Hit", true);
                        isKissing = true;
                        health += Time.deltaTime;
                        // Debug.Log("health = " + health);
                        if(health > 5){
                            dead();
                            Debug.Log(this.name + " is conquered");
                            loveSong.Play();
                        }
                    }else{
                        anim.SetBool("Hit", false);
                        isKissing = false;
                    }
                }
            }else{
                anim.SetBool("Waving", true);
                chair.transform.rotation = this.transform.rotation;
            }
        }else if(!onChair){
            agent.enabled = false;
            jumpUp();
            anim.SetBool("Hit", false);
            isKissing = false;
        }else{
            anim.SetBool("Waving", false);
            this.gameObject.transform.rotation = initRot;
            chair.transform.rotation = initRot;
        }
    }

    float CalculateHealth(){
        return health/5;
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
        Destroy(healthBarUI);
        anim.SetBool("Hit", false);
        isKissing = false;
        anim.SetTrigger("Dead");
        heartParticle.SetActive(true);
        alive = false;
    }
}