using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageSelectButton : MonoBehaviour {

	public void OnClick() {

		GetComponent<Button>().interactable = false;
		SceneManager.LoadScene(transform.name);
	}
}
