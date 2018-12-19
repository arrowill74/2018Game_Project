using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomCouple : MonoBehaviour {
	private GameObject[] men; 
	private GameObject[] enemies;
	private List<int> ranNum;
	private List<bool> allAlive;
	private int num;

	// Use this for initialization
	void Start () {
		ranNum = new List<int>();
		allAlive = new List<bool>();
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
		for(int i = 0; i < men.Length; i++){
			allAlive.Add(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < men.Length; i++){
			if(men[i].GetComponent<BusinessManController>().alive){
				break;
			}else{
				allAlive[i] = men[i].GetComponent<BusinessManController>().alive;
			}
		}
		if(checkAllDied()){
			Invoke("CompleteFunction", 1.5f);
		}
	}

	void CompleteFunction(){
		SceneManager.LoadScene("MissionComplete");
	}

	private bool checkAllDied(){
		foreach(bool manAlive in allAlive){
			if(manAlive){
				return false;
			}
		}
		return true;
	}
}
