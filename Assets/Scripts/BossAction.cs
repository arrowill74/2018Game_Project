using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAction : MonoBehaviour {

	// public variables
	public Vector3 onFloor = new Vector3(-14.847f, -0.001f, -15.108f);
	public Vector3 onChair = new Vector3(-13.43f, 1.209f, -15.108f);
	public Vector3 onTable = new Vector3(-15.46f, 1.719f, -12.72f);
	public int minTimeToChange = 2;
	public int maxTimeToChange = 10;
	// public BusinessManController businessManScript;
	public PlayerMove playerMoveScript;

	public AudioSource heartbeat;
	public AudioSource heartbeatFast;

	// private variables
	private Vector3 positionToChange;
	
	// Use this for initialization
	void Start () {
		this.positionToChange = this.onFloor;
		this.gameObject.transform.position = this.positionToChange;
		heartbeat = gameObject.GetComponent<AudioSource>();
		Invoke("changePosition", this.getChangePositionTime());
	}

	void Update () {
		if(playerMoveScript.kissingMan && this.gameObject.transform.position.Equals(onTable)){	
			if(playerMoveScript.kissingMan.GetComponent<BusinessManController>().isKissing) {
				SceneManager.LoadScene("GameOverScene");
			}
		}
	}

	private int getChangePositionTime() {
		return Random.Range(minTimeToChange, maxTimeToChange);
	}

	private void changePosition() {
		this.gameObject.transform.position = positionToChange;

		// calculate the position for next change
		if (positionToChange.Equals(onFloor)) { // boss is now on floor
			positionToChange = onChair;
			heartbeat.enabled = false;
			heartbeatFast.enabled = false;
		} else if (positionToChange.Equals(onChair)) { // boss is now on chair
			heartbeat.enabled = true;
			heartbeatFast.enabled = false;
			int randomNum = Random.Range(0, 2);
			if (randomNum == 0) {
				positionToChange = onFloor;
			} else {
				positionToChange = onTable;
			}
		} else { // boss is now on table
			positionToChange = onChair;
			heartbeat.enabled = false;
			heartbeatFast.enabled = true;
		}

		Invoke("changePosition", this.getChangePositionTime());
	}
}