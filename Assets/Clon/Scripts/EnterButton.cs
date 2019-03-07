using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterButton : MonoBehaviour {

	public void OnClick() {
		transform.parent.parent.gameObject.SetActive(false);
		GameObject.Find("GameController").GetComponent<GameController>().DisplayUI = -1;

    }
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			transform.parent.parent.gameObject.SetActive(false);
			//GameObject.Find("GameController").GetComponent<GameController>().DisplayUI = -1;
		}
	}
}
