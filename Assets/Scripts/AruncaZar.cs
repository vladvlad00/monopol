using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AruncaZar : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 vitezaZar;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		vitezaZar = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space) && vitezaZar == Vector3.zero && Base.seJoaca == false) {
            AfisareZar.nrZar = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
            transform.position = spawnRandom();
            //transform.position = new Vector3(0,2,0);
            transform.rotation = Quaternion.identity;
			rb.AddForce (new Vector3(200f,0f,100f));
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}

    private Vector3 spawnRandom()
    {
        Vector3 rez = new Vector3();
        rez.x = Random.Range(-100, 100);
        rez.y = 2;
        rez.z = Random.Range(-100, 100);
        return rez;
    }
}
