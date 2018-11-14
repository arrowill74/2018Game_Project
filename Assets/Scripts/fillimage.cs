using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillimage : MonoBehaviour {

	public Image cooldown;
    public bool coolingDown;
    public float waitTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
    }
}
