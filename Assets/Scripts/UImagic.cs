using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImagic : MonoBehaviour
{
    public Button[] scor = new Button[6];
    public static bool schimbat = false;
    public static bool upList = false;
    void Start()
    {
        for(int i = 0; i < pionus.k; i++)
        {
            scor[i].gameObject.SetActive(true);
            scor[i].GetComponentInChildren<Text>().text = Base.players[i].nume;
            Button[] butoane = scor[i].GetComponentsInChildren<Button>();
            foreach(Button b in butoane)
            {
                if (b != scor[i])
                {
                    b.GetComponentInChildren<Text>().text = Base.players[i].money.ToString();
                }
            }
        }
    }

    void Update()
    {
        if(schimbat)
        {
            for (int i = 0; i < pionus.k; i++)
            {
                Button[] butoane = scor[i].GetComponentsInChildren<Button>();
                foreach (Button b in butoane)
                {
                    if (b != scor[i])
                    {
                        b.GetComponentInChildren<Text>().text = Base.players[i].money.ToString();
                    }
                }
            }
            schimbat = false;
        }
    }

    public void updateList()
    {
        upList = true;
    }
    public void stopthat()
    {
        upList = false;
    }
}
