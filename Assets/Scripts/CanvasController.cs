using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
	public List<GameObject> UIitems;
	
	void OnEnable(){
		foreach(GameObject item in UIitems){
			item.SetActive(true);
		}
	}

	void OnDisable(){
		foreach(GameObject item in UIitems){
			item.SetActive(false);
		}
	}
}
