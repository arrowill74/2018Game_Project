using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
	public GameObject stillCam;
	public GameObject rotateCam;
	public PlayerMove PlayerMoveScript;

	// Use this for initialization
	void Start () {
		stillCam.gameObject.SetActive(true);
		rotateCam.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerMoveScript.kissingMan){
			if(PlayerMoveScript.kissingMan.GetComponent<BusinessManController>().isKissing){
				stillCam.gameObject.SetActive(false);
				rotateCam.gameObject.SetActive(true);
			}else{
				stillCam.gameObject.SetActive(true);
				rotateCam.gameObject.SetActive(false);
			}
		}
	}
}
