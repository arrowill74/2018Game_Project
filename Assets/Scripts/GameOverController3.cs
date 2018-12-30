using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController3 : MonoBehaviour {

	public void playGame() {
		SceneManager.LoadScene("Level3");
	}

	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
	
}
