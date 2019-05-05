using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickBuy : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clic);
    }

    void clic()
    {
        if(Base.crtTip == "prop")
        {
            Base.players[Base.laRand].buyProp(Base.props[Base.crtP]);
        }
        else if(Base.crtTip == "gara")
        {
            Base.players[Base.laRand].buyProp2(Base.gari[Base.crtP]);
        }
        else if(Base.crtTip == "util")
        {
            Base.players[Base.laRand].buyProp2(Base.util[Base.crtP]);
        }
    }
}
