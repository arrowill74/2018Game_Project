using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDecline : MonoBehaviour {
	public Image img;
	public float initHealth;
	
	void OnEnable(){
		img.fillAmount = initHealth;
		InvokeRepeating("TimeInjury",0,1f);
	}

	void OnDisable(){
		CancelInvoke();
	}

	void TimeInjury(){
        img.fillAmount -= 0.01f;
        if (img.fillAmount == 0) //if player life is over, cancel Invoke
        {
            CancelInvoke();
        }
    }
}
