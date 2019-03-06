using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    float jumpPower = 380f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(-5f * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(5f * Time.deltaTime, 0f, 0f);

        }
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(0f,jumpPower,0f);
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.transform.name == "Item"){
            jumpPower = 800f;
            Destroy(col.gameObject);
        }
    }
}
