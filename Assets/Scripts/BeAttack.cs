using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack : MonoBehaviour {
    public Life LifeScript; // Life's script

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "throwTool")
        {
            this.LifeScript.img.fillAmount -= 0.1f; //扣血
            Debug.Log("collision");
        }
        
        
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "throwTool")
        {
            Debug.Log("collision");
        }

    }
        
    

}
