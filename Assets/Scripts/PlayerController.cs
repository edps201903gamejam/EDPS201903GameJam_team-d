using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private Transform _transform;
	private float _speed = 20;
	private float _jumpPower = 200;
	private bool _canJump = true;
	private bool[] _foundAnimal = Enumerable.Repeat<bool>(true, 5).ToArray();
	private GameController _gameController;
	private void Start()
	{
		_transform = GetComponent<Transform>();
		_rigidbody = GetComponent<Rigidbody>();
		_foundAnimal[0] = true;
		_speed = GetComponent<Transform>().GetChild(0).GetComponent<Chara>().HorizontalSpeed;
		_jumpPower = GetComponent<Transform>().GetChild(0).GetComponent<Chara>().JumpPower;
		_gameController = Transform.FindObjectOfType<GameController>();
	}

	private void FixedUpdate()
	{
		float hInput = Input.GetAxis("Horizontal");
		int up = 0;
		if (Input.GetKeyDown(KeyCode.Space) && _canJump)
		{
			up = 1;
			_canJump = false;
		}
		FormChangeDetection(4);
		_rigidbody.AddForce(hInput * _speed * Time.fixedDeltaTime * 50, _jumpPower * up * Time.fixedDeltaTime * 50, 0);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{
			_canJump = true;
		}

	}

	private void WhenFoundAnimal(int index)
	{
		_foundAnimal[index] = true;
		_gameController.FoundAnimal(index);
	}
	
	private void FormChangeDetection(int max)
	{
		for (var i = 0; i <= max; i++)
		{
			if (Input.GetKeyDown(i.ToString()))
			{
				// Debug.Log(i.ToString()+"が押されています");
				FormChange(i);
				_gameController.CurrentAnimal(i);
			}
		}
	}
	
	public void FormChange(int index)
	{
		for (var i = 0; i < _transform.childCount; i++)
		{
			var canChange = (i == index && _foundAnimal[i]);
			if (canChange)
			{
				var chara = _transform.GetChild(i).GetComponent<Chara>();
				_speed = chara.HorizontalSpeed;
				_jumpPower = chara.JumpPower;
				Debug.Log(chara.gameObject.name + "にキャラチェンジ");
				_gameController.CurrentAnimal(i);
			}
			if (_foundAnimal[i]) _transform.GetChild(i).gameObject.SetActive(i == index);
		}
	}
	
	// getter, setter
	public bool[] FoundAnimal
	{
		get { return _foundAnimal; }
		set { _foundAnimal = value; }
	}
}