using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {

	public void OnClick() {
		transform.parent.gameObject.SetActive(false);
		transform.parent.parent.GetChild(1).gameObject.SetActive(true);
	}
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			transform.parent.gameObject.SetActive(false);
			transform.parent.parent.GetChild(1).gameObject.SetActive(true);
		}
	}
}
