using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hata : MonoBehaviour
{
	private GameController _gameController;
	private void Start ()
	{
		_gameController = Transform.FindObjectOfType<GameController>();
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("ゲームクリア");
			//_gameController.GameClear();
		}
	}
}
