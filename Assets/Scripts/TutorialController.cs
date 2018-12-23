using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {
	public DemoController demoController;
	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
	
	public void nextButtion(){
		demoController.playDemo(1);
	}

	public void prevButton(){
		demoController.playDemo(-1);
	}

	
}
