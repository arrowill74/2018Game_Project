using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCouple : MonoBehaviour {
	GameObject[] men; 
	GameObject[] enemies;
	List<int> ranNum;
	int num;

	// Use this for initialization
	void Start () {
		ranNum = new List<int>();
		men = (GameObject[])GameObject.FindGameObjectsWithTag("man");
		enemies = (GameObject[])GameObject.FindGameObjectsWithTag("enemy");
		for(int i = 0; i < enemies.Length; i ++){
			do{
				num = Random.Range(0, men.Length);
			}while(ranNum.Contains(num));
			ranNum.Add(num);
			// Debug.Log(enemies[i].name);
			EnemyController ec = enemies[i].GetComponent<EnemyController>();
			ec.boyfriend = men[ranNum[i]];
			ec.businessManScript = men[ranNum[i]].GetComponent<BusinessManController>();
			Debug.Log(enemies[i].name+" and "+men[ranNum[i]].name+" are couple.");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
