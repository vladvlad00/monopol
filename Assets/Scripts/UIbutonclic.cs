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
                    if (j != k && Base.gari[j].owner != Base.banca && Base.gari[j].owner == Base.gari[k].owner) pret *= 2;
                }
                foreach (Text t in texts)
                {
                    if (t.name == "PROPNUME") t.text = Base.gari[k].nume;
                    else if (t.name == "NUME") t.text = Base.gari[k].owner.nume;
                    else if (t.name == "CHIRIE") t.text = pret.ToString();
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
                    if (j != k && Base.gari[j].owner != Base.banca && Base.gari[j].owner == Base.gari[k].owner) pret = 10;
                }
                foreach (Text t in texts)
                {
                    if (t.name == "PROPNUME") t.text = Base.util[k].nume;
                    else if (t.name == "NUME") t.text = Base.util[k].owner.nume;
                    else if (t.name == "CHIRIE") t.text = pret.ToString() + " * Zaruri";
                }
            }
        }
    }
}