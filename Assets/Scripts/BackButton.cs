using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {
	GameObject GC;
	public void OnClick () {
		Time.timeScale = 1;
		GC = GameObject.Find("GameController");
		GameController gameController = GC.GetComponent<GameController>();
		gameController.ChangeStage(0);
	}
}
