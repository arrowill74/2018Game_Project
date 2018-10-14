using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction : MonoBehaviour {

	public Vector3 onFloor = new Vector3(-14.847f, -0.001f, -15.108f);

	public Vector3 onChair = new Vector3(-13.43f, 1.209f, -15.108f);

	public Vector3 onTable = new Vector3(-15.46f, 1.719f, -12.72f);

	private Vector3 positionToChange;

	public int minTimeToChange = 2;

	public int maxTimeToChange = 10;

	private int getChangePositionTime() {
		return Random.Range(minTimeToChange, maxTimeToChange);
	}

	private void changePosition() {
		this.gameObject.transform.position = positionToChange;

		// calculate the position for next change
		if (positionToChange.Equals(onFloor)) {
			positionToChange = onChair;

		} else if (positionToChange.Equals(onChair)) {
			int randomNum = Random.Range(0, 2);
			if (randomNum == 0) {
				positionToChange = onFloor;
			} else {
				positionToChange = onTable;
			}
		} else {
			positionToChange = onChair;
		}

		Invoke("changePosition", this.getChangePositionTime());
	}

	// Use this for initialization
	void Start () {
		this.positionToChange = this.onFloor;
		this.gameObject.transform.position = this.positionToChange;

		Invoke("changePosition", this.getChangePositionTime());
	}
}