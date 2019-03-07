using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangingFloor : MonoBehaviour
{
	private Transform _transform;
	private Vector3 originalScale;
	private float angle = 0;

	private void Start()
	{
		_transform = GetComponent<Transform>();
		originalScale = _transform.localScale;
	}

	private void Update()
	{
		_transform.localScale = originalScale + new Vector3(Mathf.Sin(angle/40) * 9f + 12, 0, 0);
		angle += 1;
	}
}
