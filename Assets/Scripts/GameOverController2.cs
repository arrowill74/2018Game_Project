using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController2 : MonoBehaviour {

	public void playGame() {
		SceneManager.LoadScene("Level2");
	}

	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
	
}
