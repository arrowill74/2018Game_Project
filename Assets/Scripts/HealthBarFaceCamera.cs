using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFaceCamera : MonoBehaviour {
	public Camera mainCam;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(transform.position+mainCam.transform.rotation*Vector3.back,
						mainCam.transform.rotation*Vector3.up);
	}
}
