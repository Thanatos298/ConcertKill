using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    private int ultPos;
    private bool posicionSel;
    private bool detectaPersonaje;
    private Transform posicion;

    public Transform[] Posiciones;

	// Use this for initialization
	void Start () {
        detectaPersonaje = false;
        ultPos = 0;
        posicionSel = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (ultPos >= Posiciones.Length)
            ultPos = 0;
        if (!posicionSel && !detectaPersonaje)
        {
            int i = Random.Range(ultPos, Posiciones.Length);
            posicion = Posiciones[i];
            var ult = Posiciones[ultPos];
            Posiciones[ultPos] = posicion;
            Posiciones[i] = ult;
            ultPos++;
            posicionSel = true;
        }
        else
        {
            if((detectaPersonaje && Vector3.Distance(transform.position, posicion.position) > 1.5f) || !detectaPersonaje)
                transform.position = Vector3.MoveTowards(transform.position, posicion.position, 5 * Time.deltaTime);
            else if (detectaPersonaje)
            {
                //Dispara
                Debug.Log("Dispara en tiempo: " + Time.time);
            }
            if (Mathf.Abs(transform.position.x - posicion.position.x) < 0.1f && Mathf.Abs(transform.position.y - posicion.position.y) < 0.1f)
                posicionSel = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectaPersonaje = true;
        posicion = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectaPersonaje = false;
        posicionSel = false;
    }
}
