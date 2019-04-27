using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfisareZar : MonoBehaviour {
    
	public static int nrZar1, nrZar2, nrZar;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (nrZar1 != 0 && nrZar2 != 0)
            nrZar = nrZar1 + nrZar2;
	}
}
