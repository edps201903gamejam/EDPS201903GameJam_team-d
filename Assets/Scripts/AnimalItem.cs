using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalItem : MonoBehaviour
{
	private Transform _transform;
	private float currentY;
	private float angle = 0;
	[SerializeField] private int index;
	
	// Use this for initialization
	void Start ()
	{
		_transform = GetComponent<Transform>();
		currentY = _transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.Rotate(0,0,-5);
		var currentPos = _transform.position;
		_transform.position = new Vector3(currentPos.x, currentY + Mathf.Sin(angle / 10) * 0.3f , currentPos.z);
		angle += 1;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(this.gameObject);
			Transform.FindObjectOfType<PlayerController>().WhenFoundAnimal(index);
		}
	}
}
