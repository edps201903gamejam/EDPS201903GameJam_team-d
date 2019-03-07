using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazaiController : MonoBehaviour {
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Transform.FindObjectOfType<GameController>().FoundMazai();
			Destroy(this.gameObject);
		}
	}
}
