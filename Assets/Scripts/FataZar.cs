using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FataZar : MonoBehaviour {

	Vector3 vitezaZar;

	// Update is called once per frame
	void FixedUpdate () {
        vitezaZar = AruncaZar.vitezaZar;
	}

	void OnTriggerStay(Collider col)
	{
		if (vitezaZar.x == 0f && vitezaZar.y == 0f && vitezaZar.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side1":
                AfisareZar.nrZar = 6;
		        break;
			case "Side2":
                AfisareZar.nrZar = 5;
				break;
			case "Side3":
                AfisareZar.nrZar = 4;
			    break;
			case "Side4":
                AfisareZar.nrZar = 3;
				break;
			case "Side5":
                AfisareZar.nrZar = 2;
				break;
			case "Side6":
                AfisareZar.nrZar = 1;
				break;
			}
		}
	}
}
