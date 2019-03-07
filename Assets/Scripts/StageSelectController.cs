using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectController : MonoBehaviour {
	private bool[] crearStageList;
	GameController gameController;
	[SerializeField] private GameObject[,] stageSelect = new GameObject[3, 2];
	// Use this for initialization
	void Start() {

	}

	public void SetStageSelect() {
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		crearStageList = gameController.ClearStageList;
		int count = 0;
		for (int i = 0; i < 3; i++) {
			for (int k = 0; k < 2; k++) {
				stageSelect[i, k] = transform.GetChild(count).gameObject;
				count++;
			}
		}
		for (int i = 0; i< 3; i++) {
			if(i != 0) {
				if (crearStageList[i - 1]) {
					stageSelect[i, 0].SetActive(true);
					stageSelect[i, 1].SetActive(false);
				}

			}
			if (crearStageList[i]) {
				stageSelect[i, 0].transform.Find("crown").gameObject.SetActive(true);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
