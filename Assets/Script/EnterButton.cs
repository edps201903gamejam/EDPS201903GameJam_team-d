using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterButton : MonoBehaviour {

	public void OnClick() {
        transform.parent.gameObject.SetActive(false);
    }
}
