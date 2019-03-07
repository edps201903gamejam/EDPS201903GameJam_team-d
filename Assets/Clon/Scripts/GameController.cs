using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	float timer;
	int mazaiSum;
	public GameObject[] animalUI = new GameObject[3];
	public bool[] foundAnimal = new bool[3];
	public int DisplayUI = -1;//-1だったら表示されていない。
	Transform canvInAnimal;
	// Use this for initialization
	void Start () {
		canvInAnimal = GameObject.Find("Animal").transform;
		for(int i = 0; i<2; i++) {
			animalUI[i] = canvInAnimal.GetChild(i).gameObject;
		}

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	public void FoundAnimal(int a) {
		foundAnimal[a] = true;
		DisplayUI = a;
		if(DisplayUI != -1) {
			animalUI[DisplayUI].SetActive(false);
		}
		animalUI[a].SetActive(true);
	}

	public void FoundMazai() {
		timer -= 10;
		mazaiSum++;
	}
}
