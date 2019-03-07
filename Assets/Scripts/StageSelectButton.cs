using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageSelectButton : MonoBehaviour {
	GameObject GC;
	public void OnClick() {
		GetComponent<Button>().interactable = false;
		GC = GameObject.Find("GameController");
		GameController gameController = GC.GetComponent<GameController>();
		gameController.ChangeStage(int.Parse(transform.name.Replace("Stage", "")));
	}
}
