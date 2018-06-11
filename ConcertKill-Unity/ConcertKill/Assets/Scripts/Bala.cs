using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public static Vector3 direccion;
    //public static int danio;
    private Vector3 mov;

	// Use this for initialization
	void Start () {
        mov = direccion;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, mov, 8 * Time.deltaTime);
        if (transform.position == Vector3.MoveTowards(transform.position, mov, 8 * Time.deltaTime))
            Destroy(gameObject);
	}
}
