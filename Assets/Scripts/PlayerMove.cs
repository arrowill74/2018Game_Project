using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float moveSpeed;
    public bool onGround = true; // Sphere grounded or not
    public Animator anim;
    public int walk = 0;
    public int jump = 0;
    public CollisionListScript collided;
    public GameObject kissingMan;

    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        moveSpeed = 5f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow)) {
            walk = 1;
        } else {
            walk = 0;
        }
        if(collided.target){
            // Debug.Log(collided.target.name);
            if(collided.target.tag == "sensor"){
                // Debug.Log(collided.target.transform.parent.tag);
                kissingMan = collided.target.transform.parent.gameObject;
            }
        }
        if(Input.GetKey(KeyCode.F)){
            anim.SetBool("hit", true);
        }else{
            anim.SetBool("hit", false);
        }
        
        anim.SetInteger("walk", walk);
        if (Input.GetKey(KeyCode.Space)) {
            jump = 1;
        } else {
            jump = 0;
        }
        anim.SetInteger("jump", jump);
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 70f, 0);

        if (onGround == true) // If the sphere is grounded
        {
            if (Input.GetKeyDown(KeyCode.Space)) // And if the player press Space
            {
                rb.AddRelativeForce(0f, 200f, 0f); // The sphere will jump
                onGround = false; // The sphere can't jump if it's in the air
            }

        }

    }

}

