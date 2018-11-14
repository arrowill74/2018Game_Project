using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour {
    Image img;
    // Use this for initialization
    void Start () {
        img = GetComponent<Image>(); //獲取Image元件
        InvokeRepeating("TimeInjury",0,1f);
	}
	
	// Update is called once per frame
	void Update () {
        //if he is attack by enemy 
    }

    void TimeInjury(){
        img.fillAmount -= 0.01f;
        if (img.fillAmount == 0) //if player life is over, cancel Invoke
        {
            CancelInvoke();
            Debug.Log("沒血了");
            SceneManager.LoadScene("GameOverScene"); //Turn to GameOverScene
        
        } 
    }
}
