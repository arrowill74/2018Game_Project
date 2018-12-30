using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController1 : MonoBehaviour {

	public void playGame() {
		SceneManager.LoadScene("Level1");
	}

	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
	
}
