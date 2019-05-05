using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbutonclic : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clic);
    }

    void clic()
    {
        setPreviewProp.crtID = name;
    }

    void Update()
    {
        if(UImagic.upList == true)
        {
            if (name != "gara1" && name != "gara2" && name != "gara3" && name != "gara4" && name != "util1" && name != "util2")
            {
                int k = 0;
                Text[] texts = GetComponentsInChildren<Text>();
                foreach (Text t in texts)
                {
                    if (t.name == "ID") k = int.Parse(t.text);
                }
                foreach (Text t in texts)
                {
                    if (t.name == "PROPNUME") t.text = Base.props[k].nume;
                    else if (t.name == "NUME") t.text = Base.props[k].owner.nume;
                    else if (t.name == "CHIRIE") t.text = Base.props[k].chirie[Base.props[k].numarCase].ToString();
                }
                Image[] iT = GetComponentsInChildren<Image>();
                foreach(Image i in iT)
                {
                    if (i.name == "IsItMine")
                    {
                        if (Base.props[k].owner.id == Base.players[Base.laRand].id) i.enabled = true;
                        else i.enabled = false;
                    }
                }
            }
            else if(name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
            {
                int k = 0;
                int pret = 25;
                Text[] texts = GetComponentsInChildren<Text>();
                foreach (Text t in texts)
                {
                    if (t.name == "ID") k = int.Parse(t.text);
                }
                for (int j = 0; j <= 3; j++)
                {
                    if (j != k && Base.gari[j].owner.id != Base.banca.id && Base.gari[j].owner.id == Base.gari[k].owner.id && Base.gari[k].ipotecat == false) pret *= 2;
                }
                foreach (Text t in texts)
                {
                    if (t.name == "PROPNUME") t.text = Base.gari[k].nume;
                    else if (t.name == "NUME") t.text = Base.gari[k].owner.nume;
                    else if (t.name == "CHIRIE") t.text = pret.ToString();
                }
                Image[] iT = GetComponentsInChildren<Image>();
                foreach (Image i in iT)
                {
                    if (i.name == "IsItMine")
                    {
                        if (Base.gari[k].owner.id == Base.players[Base.laRand].id) i.enabled = true;
                        else i.enabled = false;
                    }
                }
            }
            else if(name == "util1" || name == "util2")
            {
                int k = 0;
                int pret = 4;
                Text[] texts = GetComponentsInChildren<Text>();
                foreach (Text t in texts)
                {
                    if (t.name == "ID") k = int.Parse(t.text);
                }
                for (int j = 0; j <= 1; j++)
                {
                    if (j != k && Base.util[j].owner.id != Base.banca.id && Base.util[j].owner.id == Base.util[k].owner.id && Base.util[k].ipotecat == false) pret = 10;
                }
                foreach (Text t in texts)
                {
                    if (t.name == "PROPNUME") t.text = Base.util[k].nume;
                    else if (t.name == "NUME") t.text = Base.util[k].owner.nume;
                    else if (t.name == "CHIRIE") t.text = pret.ToString() + " * Zaruri";
                }
                Image[] iT = GetComponentsInChildren<Image>();
                foreach (Image i in iT)
                {
                    if (i.name == "IsItMine")
                    {
                        if (Base.util[k].owner.id == Base.players[Base.laRand].id) i.enabled = true;
                        else i.enabled = false;
                    }
                }
            }
        }
    }
}