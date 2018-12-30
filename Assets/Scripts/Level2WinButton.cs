using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2WinButton : MonoBehaviour {

	public void nextLevel(){
		SceneManager.LoadScene("Level3");
	}

	public void retry() {
		SceneManager.LoadScene("Level2");
	}

	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
}
