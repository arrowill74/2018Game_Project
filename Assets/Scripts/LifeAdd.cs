using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAdd : MonoBehaviour {
	public Image img;
	void OnEnable(){
		img.fillAmount += 0.2f;
	}
}
