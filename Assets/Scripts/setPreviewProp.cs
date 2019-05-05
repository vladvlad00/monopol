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
    public GameObject exit;
    public GameObject buyProp;
    public GameObject propPrev;
    public GameObject editProp;
    public GameObject casaplus;
    public GameObject casaminus;
    public GameObject ipotec;
    public GameObject ipont;

    public Sprite[] sp = new Sprite[7];

    public static string crtID = null;
    public static bool iesi = false;

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

    int crtcrtID;

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
                crtcrtID = 1;
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
                crtcrtID = 3;
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
                crtcrtID = 6;
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
                crtcrtID = 8;
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
                crtcrtID = 9;
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
                crtcrtID = 11;
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
                crtcrtID = 13;
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
                crtcrtID = 14;
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
                crtcrtID = 16;
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
                crtcrtID = 18;
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
                crtcrtID = 19;
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
                crtcrtID = 21;
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
                crtcrtID = 23;
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
                crtcrtID = 24;
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
                crtcrtID = 26;
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
                crtcrtID = 27;
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
                crtcrtID = 29;
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
                crtcrtID = 31;
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
                crtcrtID = 32;
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
                crtcrtID = 34;
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
                crtcrtID = 37;
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
                crtcrtID = 39;
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
                crtcrtID = 100;
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
                crtcrtID = 101;
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
                crtcrtID = 102;
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
                crtcrtID = 103;
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
                crtcrtID = 1000;
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
                crtcrtID = 1001;
                p.SetActive(false);
                g.SetActive(false);
                u.SetActive(true);
                sc.SetActive(false);
                uNume.text = Base.util[1].nume;
                uIpotecare.text = Base.util[1].ipoteca.ToString();
                uImage.sprite = sp[4];
            }
            #endregion
            #region sansa cufar
            else
            {
                p.SetActive(false);
                g.SetActive(false);
                u.SetActive(false);
                sc.SetActive(true);
                scText.text = GetComponent<Base>().scTxt[int.Parse(crtID)];
            }
            #endregion
            if(crtcrtID < 100)
            {
                if (Base.props[crtcrtID].numarCase != 0) pValChirie.color = Color.black;
                if (Base.props[crtcrtID].numarCase != 1) pChirie1.color = Color.black;
                if (Base.props[crtcrtID].numarCase != 2) pChirie2.color = Color.black;
                if (Base.props[crtcrtID].numarCase != 3) pChirie3.color = Color.black;
                if (Base.props[crtcrtID].numarCase != 4) pChirie4.color = Color.black;
                if (Base.props[crtcrtID].numarCase != 5) pChirie5.color = Color.black;
                if (Base.props[crtcrtID].numarCase == 0) pValChirie.color = Rosu;
                else if (Base.props[crtcrtID].numarCase == 1) pChirie1.color = Rosu;
                else if (Base.props[crtcrtID].numarCase == 2) pChirie2.color = Rosu;
                else if (Base.props[crtcrtID].numarCase == 3) pChirie3.color = Rosu;
                else if (Base.props[crtcrtID].numarCase == 4) pChirie4.color = Rosu;
                else if (Base.props[crtcrtID].numarCase == 5) pChirie5.color = Rosu;
                Base.props[crtcrtID].Updateprop();
            }
            if(crtcrtID >= 100 && crtcrtID < 1000)
            {
                if (Base.gari[crtcrtID % 100].numarGari() != 1) gChirie1.color = Color.black;
                if (Base.gari[crtcrtID % 100].numarGari() != 2) gChirie2.color = Color.black;
                if (Base.gari[crtcrtID % 100].numarGari() != 3) gChirie3.color = Color.black;
                if (Base.gari[crtcrtID % 100].numarGari() != 4) gChirie4.color = Color.black;
                if (Base.gari[crtcrtID % 100].numarGari() == 1) gChirie1.color = Rosu;
                else if (Base.gari[crtcrtID % 100].numarGari() == 2) gChirie2.color = Rosu;
                else if (Base.gari[crtcrtID % 100].numarGari() == 3) gChirie3.color = Rosu;
                else if (Base.gari[crtcrtID % 100].numarGari() == 4) gChirie4.color = Rosu;
            }
            crtID = null;
            //ce apare in plus
            if (Base.inBuyScreen == true)
            {
                exit.SetActive(false);
                buyProp.SetActive(true);
                propPrev.SetActive(true);
            }
            else
            {
                exit.SetActive(true);
                buyProp.SetActive(false);
                propPrev.SetActive(true);
                if (crtcrtID < 100)
                {
                    if (Base.props[crtcrtID].owner.id == Base.players[Base.laRand].id)
                    {
                        editProp.SetActive(true);
                        if (Base.props[crtcrtID].numarCase < 5) casaplus.GetComponent<Button>().interactable = true;
                        if (Base.props[crtcrtID].numarCase > 0) casaminus.GetComponent<Button>().interactable = true;
                        if (Base.props[crtcrtID].ipotecat == false)
                        {
                            ipotec.GetComponent<Button>().interactable = true;
                            ipont.GetComponent<Button>().interactable = false;
                        }
                        else
                        {
                            ipotec.GetComponent<Button>().interactable = false;
                            ipont.GetComponent<Button>().interactable = true;
                        }
                    }
                }
                else if (crtcrtID >= 100 && crtcrtID < 1000)
                {
                    if (Base.gari[crtcrtID % 100].owner.id == Base.players[Base.laRand].id)
                    {
                        editProp.SetActive(true);
                        casaplus.GetComponent<Button>().interactable = false;
                        casaminus.GetComponent<Button>().interactable = false;
                        if (Base.gari[crtcrtID % 100].ipotecat == false)
                        {
                            ipotec.GetComponent<Button>().interactable = true;
                            ipont.GetComponent<Button>().interactable = false;
                        }
                        else
                        {
                            ipotec.GetComponent<Button>().interactable = false;
                            ipont.GetComponent<Button>().interactable = true;
                        }
                    }
                }
                else if (crtcrtID >= 1000)
                {
                    if (Base.util[crtcrtID % 1000].owner.id == Base.players[Base.laRand].id)
                    {
                        editProp.SetActive(true);
                        casaplus.GetComponent<Button>().interactable = false;
                        casaminus.GetComponent<Button>().interactable = false;
                        if (Base.util[crtcrtID % 1000].ipotecat == false)
                        {
                            ipotec.GetComponent<Button>().interactable = true;
                            ipont.GetComponent<Button>().interactable = false;
                        }
                        else
                        {
                            ipotec.GetComponent<Button>().interactable = false;
                            ipont.GetComponent<Button>().interactable = true;
                        }
                    }
                }
                else
                {
                    editProp.SetActive(false);
                }

            }
        }
        if(iesi == true)
        {
            propPrev.SetActive(false);
            buyProp.SetActive(false);
            iesi = false;
        }
    }
    
    public void ConstrCasa()
    {
        Base.props[crtcrtID].Build();
        if (Base.props[crtcrtID].numarCase < 5) casaplus.GetComponent<Button>().interactable = true;
    }

    public void VindeCasa()
    {
        Base.props[crtcrtID].Demolish();
        if (Base.props[crtcrtID].numarCase < 1) casaminus.GetComponent<Button>().interactable = false;
    }

    public void Ipotecare()
    {
        if (crtcrtID < 100)
        {
            if (Base.props[crtcrtID].numarCase > 0) UImagic.showERR = 9;
            else Base.props[crtcrtID].Ipotecare();
        }
        else if (crtcrtID >= 100 && crtcrtID < 1000) Base.gari[crtcrtID % 100].Ipotecare();
        else if (crtcrtID >= 1000) Base.util[crtcrtID % 1000].Ipotecare();
        ipotec.GetComponent<Button>().interactable = false;
        ipont.GetComponent<Button>().interactable = true;
    }

    public void DeIpotecare()
    {
        if (crtcrtID < 100) Base.props[crtcrtID].deIpotecare();
        else if (crtcrtID >= 100 && crtcrtID < 1000) Base.gari[crtcrtID % 100].deIpotecare();
        else if (crtcrtID >= 1000) Base.util[crtcrtID % 1000].deIpotecare();
        ipotec.GetComponent<Button>().interactable = true;
        ipont.GetComponent<Button>().interactable = false;
    }
}
