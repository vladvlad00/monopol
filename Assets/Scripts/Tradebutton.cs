using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tradebutton : MonoBehaviour
{
    public GameObject dreptunghiuriSt;
    public GameObject dreptunghiuriDr;
    public bool stanga = true;
    public bool selectat = false;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(licc);
    }

    void licc()
    {
        if (stanga)
        {
            if (!selectat)
            {
                if (name != "gara1" && name != "gara2" && name != "gara3" && name != "gara4" && name != "util1" && name != "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.props[k].owner.id == Trade.plST.id)
                    {
                        Trade.pST[Trade.nrpST++] = Base.props[k];
                        selectat = true;
                    }
                }
                else if (name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.gari[k].owner.id == Trade.plST.id)
                    {
                        Trade.gST[Trade.nrgST++] = Base.gari[k];
                        selectat = true;
                    }
                }
                else if (name == "util1" || name == "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.util[k].owner.id == Trade.plST.id)
                    {
                        Trade.uST[Trade.nruST++] = Base.util[k];
                        selectat = true;
                    }
                }
            }
            else
            {
                if (name != "gara1" && name != "gara2" && name != "gara3" && name != "gara4" && name != "util1" && name != "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.props[k].owner.id == Trade.plST.id)
                    {
                        for (int i = 0; i < Trade.nrpST; i++)
                        {
                            if (Trade.pST[i].SID == Base.props[k].SID)
                            {
                                while (i < Trade.nrpST - 1)
                                {
                                    Trade.pST[i] = Trade.pST[i + 1];
                                    i++;
                                }
                                Trade.nrpST--;
                            }
                        }
                        selectat = false;
                    }
                }
                else if (name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.gari[k].owner.id == Trade.plST.id)
                    {
                        for (int i = 0; i < Trade.nrgST; i++)
                        {
                            if (Trade.gST[i].SID == Base.gari[k].SID)
                            {
                                while (i < Trade.nrgST - 1)
                                {
                                    Trade.gST[i] = Trade.gST[i + 1];
                                    i++;
                                }
                                Trade.nrgST--;
                            }
                        }
                        selectat = false;
                    }
                }
                else if (name == "util1" || name == "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.util[k].owner.id == Trade.plST.id)
                    {
                        for (int i = 0; i < Trade.nruST; i++)
                        {
                            if (Trade.uST[i].SID == Base.util[k].SID)
                            {
                                while (i < Trade.nruST - 1)
                                {
                                    Trade.uST[i] = Trade.uST[i + 1];
                                    i++;
                                }
                                Trade.nruST--;
                            }
                        }
                        selectat = false;
                    }
                }
            }

            int pozUpd = 1;
            Image[] drpt = dreptunghiuriSt.GetComponentsInChildren<Image>();
            for (int i = 0; i < Trade.nrpST; i++)
                foreach (Image im in drpt)
                    if (im.name == pozUpd.ToString())
                    {
                        im.GetComponent<Outline>().enabled = true;
                        im.GetComponentInChildren<Text>().text = Trade.pST[i].nume;
                        pozUpd++;
                        break;
                    }
            for (int i = 0; i < Trade.nrgST; i++)
                foreach (Image im in drpt)
                    if (im.name == pozUpd.ToString())
                    {
                        im.GetComponent<Outline>().enabled = true;
                        im.GetComponentInChildren<Text>().text = Trade.gST[i].nume;
                        pozUpd++;
                        break;
                    }
            for (int i = 0; i < Trade.nruST; i++)
                foreach (Image im in drpt)
                    if (im.name == pozUpd.ToString())
                    {
                        im.GetComponent<Outline>().enabled = true;
                        im.GetComponentInChildren<Text>().text = Trade.uST[i].nume;
                        pozUpd++;
                        break;
                    }
            foreach (Image im in drpt)
                if (int.Parse(im.name) >= pozUpd)
                {
                    im.GetComponent<Outline>().enabled = false;
                    im.GetComponentInChildren<Text>().text = "";
                }
        }
        else
        {
            if (!selectat)
            {
                if (name != "gara1" && name != "gara2" && name != "gara3" && name != "gara4" && name != "util1" && name != "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.props[k].owner.id == Trade.plDR.id)
                    {
                        Trade.pDR[Trade.nrpDR++] = Base.props[k];
                        selectat = true;
                    }
                }
                else if (name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.gari[k].owner.id == Trade.plDR.id)
                    {
                        Trade.gDR[Trade.nrgDR++] = Base.gari[k];
                        selectat = true;
                    }
                }
                else if (name == "util1" || name == "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.util[k].owner.id == Trade.plDR.id)
                    {
                        Trade.uDR[Trade.nruDR++] = Base.util[k];
                        selectat = true;
                    }
                }
            }
            else
            {
                if (name != "gara1" && name != "gara2" && name != "gara3" && name != "gara4" && name != "util1" && name != "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.props[k].owner.id == Trade.plDR.id)
                    {
                        for (int i = 0; i < Trade.nrpDR; i++)
                        {
                            if (Trade.pDR[i].SID == Base.props[k].SID)
                            {
                                while (i < Trade.nrpDR - 1)
                                {
                                    Trade.pDR[i] = Trade.pDR[i + 1];
                                    i++;
                                }
                                Trade.nrpDR--;
                            }
                        }
                        selectat = false;
                    }
                }
                else if (name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.gari[k].owner.id == Trade.plDR.id)
                    {
                        for (int i = 0; i < Trade.nrgDR; i++)
                        {
                            if (Trade.gDR[i].SID == Base.gari[k].SID)
                            {
                                while (i < Trade.nrgDR - 1)
                                {
                                    Trade.gDR[i] = Trade.gDR[i + 1];
                                    i++;
                                }
                                Trade.nrgDR--;
                            }
                        }
                        selectat = false;
                    }
                }
                else if (name == "util1" || name == "util2")
                {
                    int k = 0;
                    Text[] texts = GetComponentsInChildren<Text>();
                    foreach (Text t in texts)
                    {
                        if (t.name == "ID") k = int.Parse(t.text);
                    }
                    if (Base.util[k].owner.id == Trade.plDR.id)
                    {
                        for (int i = 0; i < Trade.nruDR; i++)
                        {
                            if (Trade.uDR[i].SID == Base.util[k].SID)
                            {
                                while (i < Trade.nruDR - 1)
                                {
                                    Trade.uDR[i] = Trade.uDR[i + 1];
                                    i++;
                                }
                                Trade.nruDR--;
                            }
                        }
                        selectat = false;
                    }
                }
            }

            int pozUpd = 1;
            Image[] drpt = dreptunghiuriDr.GetComponentsInChildren<Image>();
            for (int i = 0; i < Trade.nrpDR; i++)
                foreach (Image im in drpt)
                    if (im.name == pozUpd.ToString())
                    {
                        im.GetComponent<Outline>().enabled = true;
                        im.GetComponentInChildren<Text>().text = Trade.pDR[i].nume;
                        pozUpd++;
                        break;
                    }
            for (int i = 0; i < Trade.nrgDR; i++)
                foreach (Image im in drpt)
                    if (im.name == pozUpd.ToString())
                    {
                        im.GetComponent<Outline>().enabled = true;
                        im.GetComponentInChildren<Text>().text = Trade.gDR[i].nume;
                        pozUpd++;
                        break;
                    }
            for (int i = 0; i < Trade.nruDR; i++)
                foreach (Image im in drpt)
                    if (im.name == pozUpd.ToString())
                    {
                        im.GetComponent<Outline>().enabled = true;
                        im.GetComponentInChildren<Text>().text = Trade.uDR[i].nume;
                        pozUpd++;
                        break;
                    }
            foreach (Image im in drpt)
                if (int.Parse(im.name) >= pozUpd)
                {
                    im.GetComponent<Outline>().enabled = false;
                    im.GetComponentInChildren<Text>().text = "";
                }
        }
    }
    void Update()
    {
        if (stanga)
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
                foreach (Image i in iT)
                {
                    if (i.name == "IsItMine")
                    {
                        if (Base.props[k].owner.id == Trade.plST.id) i.enabled = true;
                        else i.enabled = false;
                    }
                    if (i.name == "grafica")
                    {
                        if (selectat == true) i.color = new Color(155f / 255, 0f, 0f, 1f);
                        else i.color = Color.white;
                    }
                }
            }
            else if (name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
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
                        if (Base.gari[k].owner.id == Trade.plST.id) i.enabled = true;
                        else i.enabled = false;
                    }
                    if (i.name == "grafica")
                    {
                        if (selectat == true) i.color = new Color(155f / 255, 0f, 0f, 1f);
                        else i.color = Color.white;
                    }
                }
            }
            else if (name == "util1" || name == "util2")
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
                        if (Base.util[k].owner.id == Trade.plST.id) i.enabled = true;
                        else i.enabled = false;
                    }
                    if (i.name == "grafica")
                    {
                        if (selectat == true) i.color = new Color(155f / 255, 0f, 0f, 1f);
                        else i.color = Color.white;
                    }
                }
            }
        }
        else
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
                foreach (Image i in iT)
                {
                    if (i.name == "IsItMine")
                    {
                        if (Base.props[k].owner.id == Trade.plDR.id) i.enabled = true;
                        else i.enabled = false;
                    }
                    if (i.name == "grafica")
                    {
                        if (selectat == true) i.color = new Color(155f / 255, 0f, 0f, 1f);
                        else i.color = Color.white;
                    }
                }
            }
            else if (name == "gara1" || name == "gara2" || name == "gara3" || name == "gara4")
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
                        if (Base.gari[k].owner.id == Trade.plDR.id) i.enabled = true;
                        else i.enabled = false;
                    }
                    if (i.name == "grafica")
                    {
                        if (selectat == true) i.color = new Color(155f / 255, 0f, 0f, 1f);
                        else i.color = Color.white;
                    }
                }
            }
            else if (name == "util1" || name == "util2")
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
                        if (Base.util[k].owner.id == Trade.plDR.id) i.enabled = true;
                        else i.enabled = false;
                    }
                    if (i.name == "grafica")
                    {
                        if (selectat == true) i.color = new Color(155f / 255, 0f, 0f, 1f);
                        else i.color = Color.white;
                    }
                }
            }
        }
    }
}
