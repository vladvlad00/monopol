using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FataZar : MonoBehaviour {

	Vector3 vitezaZar1, vitezaZar2;

	// Update is called once per frame
	void FixedUpdate () {
        vitezaZar1 = AruncaZar1.vitezaZar;
        vitezaZar2 = AruncaZar2.vitezaZar;
    }

	void OnTriggerStay(Collider col)
	{
		if (vitezaZar1.x == 0f && vitezaZar1.y == 0f && vitezaZar1.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side11":
                AfisareZar.nrZar1 = 6;
		        break;
			case "Side12":
                AfisareZar.nrZar1 = 5;
				break;
			case "Side13":
                AfisareZar.nrZar1 = 4;
			    break;
			case "Side14":
                AfisareZar.nrZar1 = 3;
				break;
			case "Side15":
                AfisareZar.nrZar1 = 2;
				break;
			case "Side16":
                AfisareZar.nrZar1 = 1;
				break;
			}
		}

        if (vitezaZar2.x == 0f && vitezaZar2.y == 0f && vitezaZar2.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side21":
                    AfisareZar.nrZar2 = 6;
                    break;
                case "Side22":
                    AfisareZar.nrZar2 = 5;
                    break;
                case "Side23":
                    AfisareZar.nrZar2 = 4;
                    break;
                case "Side24":
                    AfisareZar.nrZar2 = 3;
                    break;
                case "Side25":
                    AfisareZar.nrZar2 = 2;
                    break;
                case "Side26":
                    AfisareZar.nrZar2 = 1;
                    break;
            }
        }
    }
}
