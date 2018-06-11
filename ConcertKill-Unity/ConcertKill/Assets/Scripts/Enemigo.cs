using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    private int ultPos;
    private bool posicionSel;
    private bool detectaPersonaje;
    private Transform posicion;
    private Transform posPersonaje;

    public Transform[] Posiciones;

	// Use this for initialization
	void Start () {
        detectaPersonaje = false;
        ultPos = 0;
        posicionSel = false;
        posPersonaje = GameObject.FindWithTag("Player").transform;
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

        if (Mathf.Abs(Vector3.Distance(transform.position, posPersonaje.position)) <= 3.49f)
        {
            detectaPersonaje = true;
            posicion = posPersonaje;
        }
        else if(detectaPersonaje && Mathf.Abs(Vector3.Distance(transform.position, posPersonaje.position))> 3.49f && Mathf.Abs(Vector3.Distance(transform.position, posPersonaje.position))<3.55f) {
            detectaPersonaje = false;
            posicionSel = false;
        }
    }
}
