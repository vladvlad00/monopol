using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImagic : MonoBehaviour
{
    public Button[] scor = new Button[6];
    public GameObject[] ERRLIST = new GameObject[10];
    public static bool schimbat = false;
    public static bool upList = false;
    public static int showERR = 0;
    public static string lostplayer = null;
    public static string winnerplayer = null;
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
                    b.GetComponentInChildren<Text>().text = Base.players[i].money.ToString() + " lei";
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
                        b.GetComponentInChildren<Text>().text = Base.players[i].money.ToString() + " lei";
                    }
                }
            }
            schimbat = false;
        }
        if(showERR != 0)
        {
            ERRLIST[showERR - 1].SetActive(true);
            showERR = 0;
        }
        if (lostplayer != null)
        {
            updatelostplayer(lostplayer);
            lostplayer = null;
        }
        if(winnerplayer!=null)
        {
            updatewinnerplayer(winnerplayer);
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

    public void updatelostplayer(string s)
    {
        Text[] tT = ERRLIST[2].GetComponentsInChildren<Text>();
        foreach(Text t in tT)
        {
            if (t.name == "numepl") t.text = s;
        }
    }

    public void updatewinnerplayer(string s)
    {
        Text[] tT = ERRLIST[7].GetComponentsInChildren<Text>();
        foreach (Text t in tT)
        {
            if (t.name == "numepl") t.text = s;
        }
    }
}
