using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionListScript : MonoBehaviour {
    public GameObject target = null;

    public void OnTriggerEnter(Collider other)
    {
        target = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        target = null;
    }

}
