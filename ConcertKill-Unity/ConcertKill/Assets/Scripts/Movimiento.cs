using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    float speed = 6f;
    Animator anim;
    SpriteRenderer imagen;
    Rigidbody2D rb;
    public GameObject bala;
    Vector2 mov;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        imagen = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Bala.direccion = Vector3.down;
	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        mov = new Vector2(x,y);

        if (x == 1)
            imagen.flipX = true;
        else if (x == -1)
            imagen.flipX = false;

        if(mov != Vector2.zero)
        {
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);
        }

        Disparar(x, y);

        if (Input.GetMouseButtonDown(1))
            SuperPoder(x,y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + mov * speed * Time.deltaTime);
    }

    public void Disparar(float x, float y)
    {

        if (x > 0)
            Bala.direccion = transform.position + Vector3.right * 10;
        else if (x < 0)
            Bala.direccion = transform.position + Vector3.left * 10;
        else if (y > 0)
            Bala.direccion = transform.position + Vector3.up * 10;
        else if (y < 0)
            Bala.direccion = transform.position + Vector3.down * 10;

        if (Input.GetMouseButtonDown(0))
            Instantiate(bala, transform.position, Quaternion.identity);
    }

    public void SuperPoder(float x, float y) {

        bala.transform.localScale = new Vector3(2,2,2);
        Disparar(x, y);
        bala.transform.localScale = new Vector3(1, 1, 1);
    }
}
