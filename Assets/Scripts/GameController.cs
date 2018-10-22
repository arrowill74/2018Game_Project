using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public string returnSceneName = "SampleScene";

	public void playAgain() {
		SceneManager.LoadScene(this.returnSceneName);
	}

	public void quitGame() {
		// Quit is ignored in the editor
		Application.Quit();
	}
}
