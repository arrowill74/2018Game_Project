using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenRemain : MonoBehaviour {
	private GameObject[] men;
	private Text canvasNum;
	private int menNum;
	private string content;
	// Use this for initialization
	void Start () {
		men = (GameObject[])GameObject.FindGameObjectsWithTag("man");
		canvasNum = gameObject.GetComponent<Text>();
		content = "/6";
	}
	
	// Update is called once per frame
	void Update () {
		menNum = 0;
		foreach(GameObject man in men){
			if(man.GetComponent<BusinessManController>().alive){
				menNum++;
			}
		}
		canvasNum.text = menNum + content;
	}
}
