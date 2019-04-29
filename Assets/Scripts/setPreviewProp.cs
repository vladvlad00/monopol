using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setPreviewProp : MonoBehaviour
{
    public GameObject p;
    public GameObject g;
    public GameObject u;
    public GameObject sc;

    public Sprite[] sp = new Sprite[7];

    public static string crtID = null;

    #region imported from creare_tabla.cs

    Color AlbastruInchis = new Color(8f, 116f, 189f, 255f);
    Color VerdeInchis = new Color(33f, 177f, 89f, 255f);
    Color Galben = new Color(245f, 243f, 11f, 255f);
    Color Rosu = new Color(245f, 21f, 36f, 255f);
    Color Portocaliu = new Color(245f, 147f, 31f, 255f);
    Color Roz = new Color(220f, 57f, 152f, 255f);
    Color AlbastruDeschis = new Color(174f, 226f, 248f, 255f);
    Color Maro = new Color(153f, 86f, 57f, 255f);

    Color ConverColorToUnity(Color cl)
    {
        cl = new Color(cl.r / 255, cl.g / 255, cl.b / 255, cl.a / 255);
        return cl;
    }

    void ConvertAllColors()
    {
        AlbastruInchis = ConverColorToUnity(AlbastruInchis);
        VerdeInchis = ConverColorToUnity(VerdeInchis);
        Galben = ConverColorToUnity(Galben);
        Rosu = ConverColorToUnity(Rosu);
        Portocaliu = ConverColorToUnity(Portocaliu);
        Roz = ConverColorToUnity(Roz);
        AlbastruDeschis = ConverColorToUnity(AlbastruDeschis);
        Maro = ConverColorToUnity(Maro);
    }
    #endregion
    
    //p
    Image pImage;
    Text pNume;
    Text pValChirie;
    Text pChirie1;
    Text pChirie2;
    Text pChirie3;
    Text pChirie4;
    Text pChirie5;
    Text pIpotecare;
    Text pCost;

    //g
    Image gImage;
    Text gNume;
    Text gChirie1;
    Text gChirie2;
    Text gChirie3;
    Text gChirie4;
    Text gIpotecare;

    //u
    Image uImage;
    Text uNume;
    Text uIpotecare;

    //sc
    Text scText;

    void Start()
    {
        ConvertAllColors();
        //p
        Text[] pT = p.GetComponentsInChildren<Text>();
        foreach(Text t in pT)
        {
            if (t.name == "p NUME") pNume = t;
            if (t.name == "p VAL CHIRIE") pValChirie = t;
            if (t.name == "p CHIRIE1CASA") pChirie1 = t;
            if (t.name == "p CHIRIE2CASA") pChirie2 = t;
            if (t.name == "p CHIRIE3CASA") pChirie3 = t;
            if (t.name == "p CHIRIE4CASA") pChirie4 = t;
            if (t.name == "p CHIRIE5CASA") pChirie5 = t;
            if (t.name == "p VAL IPOTECARE") pIpotecare = t;
            if (t.name == "p COST CASA") pCost = t;
        }
        pImage = p.GetComponentInChildren<Image>();

        //g
        Text[] gT = g.GetComponentsInChildren<Text>();
        foreach(Text t in gT)
        {
            if (t.name == "g NUME") gNume = t;
            if (t.name == "g 1GARA") gChirie1 = t;
            if (t.name == "g 2GARA") gChirie2 = t;
            if (t.name == "g 3GARA") gChirie3 = t;
            if (t.name == "g 4GARA") gChirie4 = t;
            if (t.name == "g VAL IPOTECARE") gIpotecare = t;
        }
        gImage = g.GetComponentInChildren<Image>();

        //u
        Text[] uT = u.GetComponentsInChildren<Text>();
        foreach(Text t in uT)
        {
            if (t.name == "u NUME") uNume = t;
            if (t.name == "u VAL IPOTECARE") uIpotecare = t;
        }
        uImage = u.GetComponentInChildren<Image>();

        //sc
        scText = sc.GetComponentInChildren<Text>();
    }
    void Update()
    {
        if(crtID != null)
        {
            #region proprietati
            if (crtID == "maro1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Maro;
                pNume.text = Base.props[1].nume;
                pValChirie.text = Base.props[1].chirie[0].ToString();
                pChirie1.text = Base.props[1].chirie[1].ToString();
                pChirie2.text = Base.props[1].chirie[2].ToString();
                pChirie3.text = Base.props[1].chirie[3].ToString();
                pChirie4.text = Base.props[1].chirie[4].ToString();
                pChirie5.text = Base.props[1].chirie[5].ToString();
                pIpotecare.text = Base.props[1].ipoteca.ToString();
                pCost.text = Base.props[1].costCasa.ToString();
            }
            else if (crtID == "maro2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Maro;
                pNume.text = Base.props[3].nume;
                pValChirie.text = Base.props[3].chirie[0].ToString();
                pChirie1.text = Base.props[3].chirie[1].ToString();
                pChirie2.text = Base.props[3].chirie[2].ToString();
                pChirie3.text = Base.props[3].chirie[3].ToString();
                pChirie4.text = Base.props[3].chirie[4].ToString();
                pChirie5.text = Base.props[3].chirie[5].ToString();
                pIpotecare.text = Base.props[3].ipoteca.ToString();
                pCost.text = Base.props[3].costCasa.ToString();
            }
            else if (crtID == "bleu1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = AlbastruDeschis;
                pNume.text = Base.props[6].nume;
                pValChirie.text = Base.props[6].chirie[0].ToString();
                pChirie1.text = Base.props[6].chirie[1].ToString();
                pChirie2.text = Base.props[6].chirie[2].ToString();
                pChirie3.text = Base.props[6].chirie[3].ToString();
                pChirie4.text = Base.props[6].chirie[4].ToString();
                pChirie5.text = Base.props[6].chirie[5].ToString();
                pIpotecare.text = Base.props[6].ipoteca.ToString();
                pCost.text = Base.props[6].costCasa.ToString();
            }
            else if (crtID == "bleu2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = AlbastruDeschis;
                pNume.text = Base.props[8].nume;
                pValChirie.text = Base.props[8].chirie[0].ToString();
                pChirie1.text = Base.props[8].chirie[1].ToString();
                pChirie2.text = Base.props[8].chirie[2].ToString();
                pChirie3.text = Base.props[8].chirie[3].ToString();
                pChirie4.text = Base.props[8].chirie[4].ToString();
                pChirie5.text = Base.props[8].chirie[5].ToString();
                pIpotecare.text = Base.props[8].ipoteca.ToString();
                pCost.text = Base.props[8].costCasa.ToString();
            }
            else if (crtID == "bleu3")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = AlbastruDeschis;
                pNume.text = Base.props[9].nume;
                pValChirie.text = Base.props[9].chirie[0].ToString();
                pChirie1.text = Base.props[9].chirie[1].ToString();
                pChirie2.text = Base.props[9].chirie[2].ToString();
                pChirie3.text = Base.props[9].chirie[3].ToString();
                pChirie4.text = Base.props[9].chirie[4].ToString();
                pChirie5.text = Base.props[9].chirie[5].ToString();
                pIpotecare.text = Base.props[9].ipoteca.ToString();
                pCost.text = Base.props[9].costCasa.ToString();
            }
            else if (crtID == "roz1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Roz;
                pNume.text = Base.props[11].nume;
                pValChirie.text = Base.props[11].chirie[0].ToString();
                pChirie1.text = Base.props[11].chirie[1].ToString();
                pChirie2.text = Base.props[11].chirie[2].ToString();
                pChirie3.text = Base.props[11].chirie[3].ToString();
                pChirie4.text = Base.props[11].chirie[4].ToString();
                pChirie5.text = Base.props[11].chirie[5].ToString();
                pIpotecare.text = Base.props[11].ipoteca.ToString();
                pCost.text = Base.props[11].costCasa.ToString();
            }
            else if (crtID == "roz2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Roz;
                pNume.text = Base.props[13].nume;
                pValChirie.text = Base.props[13].chirie[0].ToString();
                pChirie1.text = Base.props[13].chirie[1].ToString();
                pChirie2.text = Base.props[13].chirie[2].ToString();
                pChirie3.text = Base.props[13].chirie[3].ToString();
                pChirie4.text = Base.props[13].chirie[4].ToString();
                pChirie5.text = Base.props[13].chirie[5].ToString();
                pIpotecare.text = Base.props[13].ipoteca.ToString();
                pCost.text = Base.props[13].costCasa.ToString();
            }
            else if (crtID == "roz3")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Roz;
                pNume.text = Base.props[14].nume;
                pValChirie.text = Base.props[14].chirie[0].ToString();
                pChirie1.text = Base.props[14].chirie[1].ToString();
                pChirie2.text = Base.props[14].chirie[2].ToString();
                pChirie3.text = Base.props[14].chirie[3].ToString();
                pChirie4.text = Base.props[14].chirie[4].ToString();
                pChirie5.text = Base.props[14].chirie[5].ToString();
                pIpotecare.text = Base.props[14].ipoteca.ToString();
                pCost.text = Base.props[14].costCasa.ToString();
            }
            else if (crtID == "portocaliu1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Portocaliu;
                pNume.text = Base.props[16].nume;
                pValChirie.text = Base.props[16].chirie[0].ToString();
                pChirie1.text = Base.props[16].chirie[1].ToString();
                pChirie2.text = Base.props[16].chirie[2].ToString();
                pChirie3.text = Base.props[16].chirie[3].ToString();
                pChirie4.text = Base.props[16].chirie[4].ToString();
                pChirie5.text = Base.props[16].chirie[5].ToString();
                pIpotecare.text = Base.props[16].ipoteca.ToString();
                pCost.text = Base.props[16].costCasa.ToString();
            }
            else if (crtID == "portocaliu2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Portocaliu;
                pNume.text = Base.props[18].nume;
                pValChirie.text = Base.props[18].chirie[0].ToString();
                pChirie1.text = Base.props[18].chirie[1].ToString();
                pChirie2.text = Base.props[18].chirie[2].ToString();
                pChirie3.text = Base.props[18].chirie[3].ToString();
                pChirie4.text = Base.props[18].chirie[4].ToString();
                pChirie5.text = Base.props[18].chirie[5].ToString();
                pIpotecare.text = Base.props[18].ipoteca.ToString();
                pCost.text = Base.props[18].costCasa.ToString();
            }
            else if (crtID == "portocaliu3")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Portocaliu;
                pNume.text = Base.props[19].nume;
                pValChirie.text = Base.props[19].chirie[0].ToString();
                pChirie1.text = Base.props[19].chirie[1].ToString();
                pChirie2.text = Base.props[19].chirie[2].ToString();
                pChirie3.text = Base.props[19].chirie[3].ToString();
                pChirie4.text = Base.props[19].chirie[4].ToString();
                pChirie5.text = Base.props[19].chirie[5].ToString();
                pIpotecare.text = Base.props[19].ipoteca.ToString();
                pCost.text = Base.props[19].costCasa.ToString();
            }
            else if (crtID == "rosu1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Rosu;
                pNume.text = Base.props[21].nume;
                pValChirie.text = Base.props[21].chirie[0].ToString();
                pChirie1.text = Base.props[21].chirie[1].ToString();
                pChirie2.text = Base.props[21].chirie[2].ToString();
                pChirie3.text = Base.props[21].chirie[3].ToString();
                pChirie4.text = Base.props[21].chirie[4].ToString();
                pChirie5.text = Base.props[21].chirie[5].ToString();
                pIpotecare.text = Base.props[21].ipoteca.ToString();
                pCost.text = Base.props[21].costCasa.ToString();
            }
            else if (crtID == "rosu2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Rosu;
                pNume.text = Base.props[23].nume;
                pValChirie.text = Base.props[23].chirie[0].ToString();
                pChirie1.text = Base.props[23].chirie[1].ToString();
                pChirie2.text = Base.props[23].chirie[2].ToString();
                pChirie3.text = Base.props[23].chirie[3].ToString();
                pChirie4.text = Base.props[23].chirie[4].ToString();
                pChirie5.text = Base.props[23].chirie[5].ToString();
                pIpotecare.text = Base.props[23].ipoteca.ToString();
                pCost.text = Base.props[23].costCasa.ToString();
            }
            else if (crtID == "rosu3")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Rosu;
                pNume.text = Base.props[24].nume;
                pValChirie.text = Base.props[24].chirie[0].ToString();
                pChirie1.text = Base.props[24].chirie[1].ToString();
                pChirie2.text = Base.props[24].chirie[2].ToString();
                pChirie3.text = Base.props[24].chirie[3].ToString();
                pChirie4.text = Base.props[24].chirie[4].ToString();
                pChirie5.text = Base.props[24].chirie[5].ToString();
                pIpotecare.text = Base.props[24].ipoteca.ToString();
                pCost.text = Base.props[24].costCasa.ToString();
            }
            else if (crtID == "galben1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Galben;
                pNume.text = Base.props[26].nume;
                pValChirie.text = Base.props[26].chirie[0].ToString();
                pChirie1.text = Base.props[26].chirie[1].ToString();
                pChirie2.text = Base.props[26].chirie[2].ToString();
                pChirie3.text = Base.props[26].chirie[3].ToString();
                pChirie4.text = Base.props[26].chirie[4].ToString();
                pChirie5.text = Base.props[26].chirie[5].ToString();
                pIpotecare.text = Base.props[26].ipoteca.ToString();
                pCost.text = Base.props[26].costCasa.ToString();
            }
            else if (crtID == "galben2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Galben;
                pNume.text = Base.props[27].nume;
                pValChirie.text = Base.props[27].chirie[0].ToString();
                pChirie1.text = Base.props[27].chirie[1].ToString();
                pChirie2.text = Base.props[27].chirie[2].ToString();
                pChirie3.text = Base.props[27].chirie[3].ToString();
                pChirie4.text = Base.props[27].chirie[4].ToString();
                pChirie5.text = Base.props[27].chirie[5].ToString();
                pIpotecare.text = Base.props[27].ipoteca.ToString();
                pCost.text = Base.props[27].costCasa.ToString();
            }
            else if (crtID == "galben3")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = Galben;
                pNume.text = Base.props[29].nume;
                pValChirie.text = Base.props[29].chirie[0].ToString();
                pChirie1.text = Base.props[29].chirie[1].ToString();
                pChirie2.text = Base.props[29].chirie[2].ToString();
                pChirie3.text = Base.props[29].chirie[3].ToString();
                pChirie4.text = Base.props[29].chirie[4].ToString();
                pChirie5.text = Base.props[29].chirie[5].ToString();
                pIpotecare.text = Base.props[29].ipoteca.ToString();
                pCost.text = Base.props[29].costCasa.ToString();
            }
            else if (crtID == "verde1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = VerdeInchis;
                pNume.text = Base.props[31].nume;
                pValChirie.text = Base.props[31].chirie[0].ToString();
                pChirie1.text = Base.props[31].chirie[1].ToString();
                pChirie2.text = Base.props[31].chirie[2].ToString();
                pChirie3.text = Base.props[31].chirie[3].ToString();
                pChirie4.text = Base.props[31].chirie[4].ToString();
                pChirie5.text = Base.props[31].chirie[5].ToString();
                pIpotecare.text = Base.props[31].ipoteca.ToString();
                pCost.text = Base.props[31].costCasa.ToString();
            }
            else if (crtID == "verde2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = VerdeInchis;
                pNume.text = Base.props[32].nume;
                pValChirie.text = Base.props[32].chirie[0].ToString();
                pChirie1.text = Base.props[32].chirie[1].ToString();
                pChirie2.text = Base.props[32].chirie[2].ToString();
                pChirie3.text = Base.props[32].chirie[3].ToString();
                pChirie4.text = Base.props[32].chirie[4].ToString();
                pChirie5.text = Base.props[32].chirie[5].ToString();
                pIpotecare.text = Base.props[32].ipoteca.ToString();
                pCost.text = Base.props[32].costCasa.ToString();
            }
            else if (crtID == "verde3")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = VerdeInchis;
                pNume.text = Base.props[34].nume;
                pValChirie.text = Base.props[34].chirie[0].ToString();
                pChirie1.text = Base.props[34].chirie[1].ToString();
                pChirie2.text = Base.props[34].chirie[2].ToString();
                pChirie3.text = Base.props[34].chirie[3].ToString();
                pChirie4.text = Base.props[34].chirie[4].ToString();
                pChirie5.text = Base.props[34].chirie[5].ToString();
                pIpotecare.text = Base.props[34].ipoteca.ToString();
                pCost.text = Base.props[34].costCasa.ToString();
            }
            else if (crtID == "albastru1")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = AlbastruInchis;
                pNume.text = Base.props[37].nume;
                pValChirie.text = Base.props[37].chirie[0].ToString();
                pChirie1.text = Base.props[37].chirie[1].ToString();
                pChirie2.text = Base.props[37].chirie[2].ToString();
                pChirie3.text = Base.props[37].chirie[3].ToString();
                pChirie4.text = Base.props[37].chirie[4].ToString();
                pChirie5.text = Base.props[37].chirie[5].ToString();
                pIpotecare.text = Base.props[37].ipoteca.ToString();
                pCost.text = Base.props[37].costCasa.ToString();
            }
            else if (crtID == "albastru2")
            {
                p.SetActive(true);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(false);
                pImage.color = AlbastruInchis;
                pNume.text = Base.props[39].nume;
                pValChirie.text = Base.props[39].chirie[0].ToString();
                pChirie1.text = Base.props[39].chirie[1].ToString();
                pChirie2.text = Base.props[39].chirie[2].ToString();
                pChirie3.text = Base.props[39].chirie[3].ToString();
                pChirie4.text = Base.props[39].chirie[4].ToString();
                pChirie5.text = Base.props[39].chirie[5].ToString();
                pIpotecare.text = Base.props[39].ipoteca.ToString();
                pCost.text = Base.props[39].costCasa.ToString();
            }
            #endregion
            #region gari
            else if (crtID == "gara1")
            {
                p.SetActive(false);
                g.SetActive(true);
                u.SetActive(false);
                sc.SetActive(false);
                gNume.text = Base.gari[0].nume;
                gIpotecare.text = Base.gari[0].ipoteca.ToString();
                gChirie1.text = "25";
                gChirie2.text = "50";
                gChirie3.text = "100";
                gChirie4.text = "200";
                gImage.sprite = sp[0];
            }
            else if (crtID == "gara2")
            {
                p.SetActive(false);
                g.SetActive(true);
                u.SetActive(false);
                sc.SetActive(false);
                gNume.text = Base.gari[1].nume;
                gIpotecare.text = Base.gari[1].ipoteca.ToString();
                gChirie1.text = "25";
                gChirie2.text = "50";
                gChirie3.text = "100";
                gChirie4.text = "200";
                gImage.sprite = sp[1];
            }
            else if (crtID == "gara3")
            {
                p.SetActive(false);
                g.SetActive(true);
                u.SetActive(false);
                sc.SetActive(false);
                gNume.text = Base.gari[2].nume;
                gIpotecare.text = Base.gari[2].ipoteca.ToString();
                gChirie1.text = "25";
                gChirie2.text = "50";
                gChirie3.text = "100";
                gChirie4.text = "200";
                gImage.sprite = sp[0];
            }
            else if (crtID == "gara4")
            {
                p.SetActive(false);
                g.SetActive(true);
                u.SetActive(false);
                sc.SetActive(false);
                gNume.text = Base.gari[3].nume;
                gIpotecare.text = Base.gari[3].ipoteca.ToString();
                gChirie1.text = "25";
                gChirie2.text = "50";
                gChirie3.text = "100";
                gChirie4.text = "200";
                gImage.sprite = sp[2];
            }
            #endregion
            #region utilitati
            else if (crtID == "util1")
            {
                p.SetActive(false);
                g.SetActive(false);
                u.SetActive(true);
                sc.SetActive(false);
                uNume.text = Base.util[0].nume;
                uIpotecare.text = Base.util[0].ipoteca.ToString();
                uImage.sprite = sp[3];
            }
            else if (crtID == "util2")
            {
                p.SetActive(false);
                g.SetActive(false);
                u.SetActive(true);
                sc.SetActive(false);
                uNume.text = Base.util[1].nume;
                uIpotecare.text = Base.util[1].ipoteca.ToString();
                uImage.sprite = sp[4];
            }
            #endregion
            #region
            else
            {
                p.SetActive(false);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(true);
                //scText.text = vectorul ala[crtID];
            }
            #endregion
            crtID = null;
        }
    }

}
