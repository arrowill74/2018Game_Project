using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour {
	public List<GameObject> Demos;
	public Image right;
	public Image left;
	private int playing;

	// Use this for initialization
	void Start () {
		playing = 0;
		Demos[playing].SetActive(true);
	}

	public void playDemo(int plus){
		int current = playing;
		int next = playing + plus;
		Debug.Log(current);
		Debug.Log(next);
		Demos[next].SetActive(true);
		Demos[current].SetActive(false);
		if(next == Demos.Count-1){
			right.enabled = false;
		}else{
			right.enabled = true;
		}
		if(next == 0){
			left.enabled = false;
		}else{
			left.enabled = true;
		}
		playing = next;
	}

}
