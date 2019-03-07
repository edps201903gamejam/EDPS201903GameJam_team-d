using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour {
	[SerializeField] private float additionalGravity = 0;
	[SerializeField] private float jumpPower = 3000;
	[SerializeField] private float horizontalSpeed = 20;

	public float AdditionalGravity
	{
		get { return additionalGravity; }
	}

	public float JumpPower
	{
		get { return jumpPower; }
	}

	public float HorizontalSpeed
	{
		get { return horizontalSpeed; }
	}
}
