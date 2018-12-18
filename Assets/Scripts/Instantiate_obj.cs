using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_obj : MonoBehaviour {
	public GameObject[] Objects; //裝生成物件的陣列
	public Transform[] Points; //裝生成點的陣列
	public float Ins_time; //每幾秒生成一次
	public GameObject santa;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Ins_objs",Ins_time,Ins_time ); //重複呼叫("函式名",第一次間隔幾秒呼叫，每幾秒呼叫一次)
	}

	void Ins_objs(){
		int Random_Objects = Random.Range(0,Objects.Length); //隨機產生0~物件陣列長度的整數-1(不包含最大值所以-1)
		int Random_Points = Random.Range(0,Points.Length); //隨機產生0~生成點陣列長度的整數-1 (不包含最大值所以-1)
		Vector3 pos = santa.transform.position;
		Quaternion rot = santa.transform.rotation;
		Instantiate(Objects[Random_Objects],pos, rot);
		//Instantiate 實務化(要生成的物件，物件位置，物件旋轉值);
	}

}
