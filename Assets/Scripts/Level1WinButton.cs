using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1WinButton : MonoBehaviour {

	public void nextLevel(){
		SceneManager.LoadScene("Level2");
	}

	public void retry() {
		SceneManager.LoadScene("Level1");
	}

	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
}
