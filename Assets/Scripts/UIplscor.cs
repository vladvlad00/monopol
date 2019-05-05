using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIplscor : MonoBehaviour
{

    char[] c;

    void Start()
    {
        c = name.ToCharArray();
    }

    void Update()
    {
        ColorBlock aux = GetComponent<Button>().colors;
        if (Base.laRand == c[2] - '0' - 1 && Base.players[c[2] - '0' - 1].pierdut == false)
        {
            aux.disabledColor = new Color(0f, 200 / 255f, 0f, 232 / 255f);
            GetComponent<Button>().colors = aux;
        }
        else if(Base.laRand != c[2] - '0' - 1 && Base.players[c[2] - '0' - 1].pierdut == false)
        {
            aux.disabledColor = new Color(200 / 255f, 0f, 0f, 232 / 255f);
            GetComponent<Button>().colors = aux;
        }
        if(Base.players[c[2] - '0' - 1].pierdut == true)
        {
            aux.disabledColor = new Color(100f / 255, 100f / 255, 100f / 255, 232f / 255);
            GetComponent<Button>().colors = aux;
        }
    }
}
