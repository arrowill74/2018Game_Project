﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	
	public void playGame() {
		SceneManager.LoadScene("Level1");
	}

	public void openHint() {
		SceneManager.LoadScene("Tutorial");
	}

	public void quitGame() {
		Application.Quit();
	}
}
