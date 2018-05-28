using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    float speed = 10;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        

        var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        transform.position += move * speed * Time.deltaTime;

        anim.SetFloat("x", Input.GetAxis("Horizontal"));
        anim.SetFloat("y", Input.GetAxis("Vertical"));
    }
}
