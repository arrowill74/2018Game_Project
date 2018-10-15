using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessManController : MonoBehaviour {
    //private variables
    private Vector3 initPos;
    private Quaternion initRot;
    private Rigidbody rigidBody;
    private Animator anim;
    private bool onChair;

    //public variables
    public Vector3 onGroundPos; //set the ground position
    public GameObject FollowTarget; //look toward Player
    public CollisionListScript PlayerSensor;

    // Use this for initialization
    void Start() {
        anim = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody>();
        initPos = transform.position;
        initRot = transform.rotation;
        onChair = true;
        //Debug.Log("initPos = " + initPos);
    }

    // Update is called once per frame
    void Update() {
        if (onChair) {
            if (PlayerSensor.target) {
                jumpDown();
            }
        } else { // !onChair
            if (PlayerSensor.target) {
                FollowTarget = PlayerSensor.target;
                Vector3 lookAt = FollowTarget.gameObject.transform.position;
                lookAt.y = this.gameObject.transform.position.y;
                this.transform.LookAt(lookAt);
                if (Input.GetKey(KeyCode.F)) {
                    anim.SetBool("Hit", true);
                } else {
                    anim.SetBool("Hit", false);
                }
            } else {
                jumpUp();
            }
        }
        
    }
    void jumpDown() {
        anim.SetTrigger("Jump");
        this.gameObject.transform.position = onGroundPos;
        onChair = false;
    }

    void jumpUp() {
        anim.SetTrigger("Jump");
        this.gameObject.transform.position = initPos;
        this.gameObject.transform.rotation = initRot;
        onChair = true;
    }

    void dead() {
        anim.SetTrigger("Dead");
    }
}