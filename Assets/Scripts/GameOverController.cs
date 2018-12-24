using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	public void playGame() {
		SceneManager.LoadScene("SampleScene");
	}

	public void returnHome() {
		SceneManager.LoadScene("HomePage");
	}
	
}
