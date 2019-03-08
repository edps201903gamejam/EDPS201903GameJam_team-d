using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
	private GameController _gameController;
	private PlayerController _playerController;

	// Use this for initialization
	private void Start ()
	{
		_gameController = Transform.FindObjectOfType<GameController>();
		_playerController = Transform.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (_playerController.CurrentAnimal != 3)
			{
				_gameController.GameOver();
			}
		}
	}
}
