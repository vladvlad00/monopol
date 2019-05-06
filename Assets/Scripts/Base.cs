 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    const float hProp = 65F;
    const float lProp = 40F;
    const float h2Prop = 13.3F;
    const float marimeTabla = 490F;

    public static List<Proprietate> props = new List<Proprietate>();
    public static List<Proprietate2> gari = new List<Proprietate2>();
    public static List<Proprietate2> util = new List<Proprietate2>();
    public static List<Player> players = new List<Player>();
    public static Player banca = new Player("banca",null);
    public GameObject modelCasa;
    public GameObject modelHotel;
    public GameObject modelDegetar;
    public GameObject modelFier;
    public GameObject modelJoben;
    public GameObject modelLocomotiva;
    public GameObject modelMasina;
    public GameObject modelTun;
    public InputField textNume;
    GameObject peon;
    public GameObject[] modele = new GameObject[6];
    public static bool seJoaca = false;
    public static Vector3[,] pozPioni = new Vector3[41,6]; //poz 41 e pentru cand esti la inchisoare
    public static Vector3[,] pozCase = new Vector3[41, 5];
    public static int[] nrPlayers = new int[41];
    public static int laRand = 0;
    static bool seMisca = false;
    public static bool inBuyScreen = false;
    int nrduble = 0, pre = 0;
    public Button terminaTura;
    public Button daCuZaru;
    public static int crtP;
    public static string crtTip;
    bool sigurok = false;
    bool endgame = false;
    public GameObject fireworks;
    public GameObject ExitGame;
    List<int> listaSansa = new List<int>();
    List<int> listaCufar = new List<int>();
    int pozSansa = 0, pozCufar = 0;
    Random rng = new Random();
    public List<string> scTxt = new List<string>();
    public GameObject previewProp;
    bool dinInchisoare;
    public GameObject buton50;
    bool turaPuscarie = false;
    public static Proprietate nein = new Proprietate("nu", -1, -1, -1, -1, null, null);//adaug null pe pozitiile unde nu am proprietati
    public static Proprietate2 nein2 = new Proprietate2("nu", -1, -1, -1, null);

    public GameObject tradePropsST1;
    public GameObject tradePropsDR1;
    public GameObject tradePropsST2;
    public GameObject tradePropsDR2;
    public GameObject tradeST;
    public GameObject tradeDR;
    public GameObject ddST;
    public GameObject ddDR;
    public GameObject baniST;
    public GameObject baniDR;

    public static int[] chirii =
    {
                         2,10,30,90,160,250, //maro
                         4,20,60,180,320,450,
                         6,30,90,270,400,550, //bleu
                         6,30,90,270,400,550,
                         8,40,100,300,450,600,
                         10,50,150,450,625,750, //roz
                         10,50,150,450,625,750,
                         12,60,180,500,700,900,
                         14,70,200,550,750,950, //portocaliu
                         14,70,200,550,750,950,
                         16,80,220,600,800,1000,
                         18,90,250,700,875,1050, //rosu
                         18,90,250,700,875,1050,
                         20,100,300,750,925,1100,
                         22,110,330,800,975,1150, //galben
                         22,110,330,800,975,1150,
                         24,120,360,850,1025,1200,
                         26,130,390,900,1100,1275, //verde
                         26,130,390,900,1100,1275,
                         28,150,450,1000,1200,1400,
                         35,175,500,1100,1300,1500, //albastru
                         50,200,600,1400,1700,2000
    };

    public static int[] preturi =
    {
        60, 60, //maro
        100, 100, 120, //bleu
        140, 140, 160, //roz
        180, 180, 200, //portocaliu
        220, 220, 240, //rosu
        260, 260, 280, //galben
        300, 300, 320, //verde
        350, 400, //albastru
        150, 200, //utilitati si gari 22 23
        100, 200 //taxe 24 25
    };

    void Start()
    {
        Proprietate.modelCasa = modelCasa;
        Proprietate.modelHotel = modelHotel;
        InitProps();
        InitPoz();
        InitBanca();
        InitSanse();
        /*
        test = Instantiate(modelDegetar, new Vector3(-220f, 3f, -220f), Quaternion.AngleAxis(-90f, new Vector3(1, 0, 0))) as GameObject;
        test.AddComponent<Rigidbody>();
        test.AddComponent<BoxCollider>();
        yield return StartCoroutine(misca());
        yield return StartCoroutine(misca());
        yield return StartCoroutine(misca());*/
    }

    //initializare banca
    void InitBanca()
    {
        banca.money = 999999;
        banca.nume = "Banca";
        banca.id = 100;
        foreach (Proprietate p in props)
        {
            p.SetOwner(banca);
        }
        foreach (Proprietate2 p in gari)
        {
            p.SetOwner(banca);
        }
        foreach (Proprietate2 p in util)
        {
            p.SetOwner(banca);
        }
    }

    //initializare proprietati
    void InitProps()
    {
        
        #region MARO
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["maro2"], preturi[0], 30, 50, 0, "maro","maro1"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["maro1"], preturi[1], 30, 50, 1, "maro", "maro2"));
        #endregion
        props.Add(nein);
        props.Add(nein);
        #region BLEU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["bleu3"], preturi[2], 50, 50, 2, "bleu", "bleu1"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["bleu2"], preturi[3], 50, 50, 3, "bleu", "bleu2"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["bleu1"], preturi[4], 60, 50, 4, "bleu", "bleu3"));
        #endregion
        props.Add(nein);
        #region ROZ
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["roz3"], preturi[5], 70, 100, 5, "roz", "roz1"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["roz2"], preturi[6], 70, 100, 6, "roz", "roz2"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["roz1"], preturi[7], 80, 100, 7, "roz", "roz3"));
        #endregion
        props.Add(nein);
        #region PORTOCALIU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["portocaliu3"], preturi[8], 90, 100, 8, "portocaliu", "portocaliu1"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["portocaliu2"], preturi[9], 90, 100, 9, "portocaliu", "portocaliu2"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["portocaliu1"], preturi[10], 100, 100, 10, "portocaliu", "portocaliu3"));
        #endregion
        props.Add(nein);
        #region ROSU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["rosu3"], preturi[11], 110, 150, 11, "rosu", "rosu1"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["rosu2"], preturi[12], 110, 150, 12, "rosu", "rosu2"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["rosu1"], preturi[13], 120, 150, 13, "rosu", "rosu3"));
        #endregion
        props.Add(nein);
        #region GALBEN
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["galben3"], preturi[14], 130, 150, 14, "galben", "galben1"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["galben2"], preturi[15], 130, 150, 15, "galben", "galben2"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["galben1"], preturi[16], 140, 150, 16, "galben", "galben3"));
        #endregion
        props.Add(nein);
        #region VERDE
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["verde3"], preturi[17], 150, 200, 17, "verde", "verde1"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["verde2"], preturi[18], 150, 200, 18, "verde", "verde2"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["verde1"], preturi[19], 160, 200, 19, "verde", "verde3"));
        #endregion
        props.Add(nein);
        props.Add(nein);
        #region ALBASTRU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["albastru2"], preturi[20], 175, 200, 20, "albastru", "albastru1"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["albastru1"], preturi[21], 200, 200, 21, "albastru", "albastru2"));
        #endregion
        int k = 0;
        for (int i = 0; i < 22;)
        {
            if (props[k].nume != "nu")
            {
                for (int j = 0; j < 6; j++)
                    props[k].chirie[j] = chirii[i * 6 + j];
                i++;
                props[k].chiried = props[k].chirie[0] * 2;
                props[k].oldchir = props[k].chirie[0];
            }
            k++;
        }
        #region UTILITATI
        util.Add(new Proprietate2(GetComponent<creare_tabla>().names["util1"], preturi[22], 75, 0, "util1"));
        util.Add(new Proprietate2(GetComponent<creare_tabla>().names["util2"], preturi[22], 75, 1, "util2"));
        #endregion
        #region GARI
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara1"], preturi[23], 100, 0, "gara1"));
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara2"], preturi[23], 100, 1, "gara2"));
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara3"], preturi[23], 100, 2, "gara3"));
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara4"], preturi[23], 100, 3, "gara4"));
        #endregion
    }

    public void InitPlayer()
    {
        string nume = textNume.text;
        peon = Instantiate(modele[pionus.i], pozPioni[0, nrPlayers[0]], Quaternion.Euler(270f, 0f, 0f)) as GameObject;
        peon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //peon.AddComponent<Rigidbody>();
        //peon.AddComponent<BoxCollider>();
        players.Add(new Player(nume,peon));
    }

    void InitPoz()
    {
        #region START
        pozPioni[0, 0].x =  - marimeTabla / 2 + hProp / 2;
        pozPioni[0, 0].y = 1.75f;
        pozPioni[0, 0].z =  - marimeTabla / 2 + hProp / 2 + 10;

        pozPioni[0, 1].x = pozPioni[0, 0].x + hProp / 4;
        pozPioni[0, 1].y = 1.75f; ;
        pozPioni[0, 1].z = pozPioni[0, 0].z;

        pozPioni[0, 2].x = pozPioni[0, 0].x - hProp / 4;
        pozPioni[0, 2].y = 1.75f; ;
        pozPioni[0, 2].z = pozPioni[0, 0].z;

        pozPioni[0, 3].x = pozPioni[0, 0].x;
        pozPioni[0, 3].y = 1.75f; ;
        pozPioni[0, 3].z = pozPioni[0, 0].z - hProp / 4;

        pozPioni[0, 4].x = pozPioni[0, 3].x + hProp / 4;
        pozPioni[0, 4].y = 1.75f; ;
        pozPioni[0, 4].z = pozPioni[0, 3].z;

        pozPioni[0, 5].x = pozPioni[0, 3].x - hProp / 4;
        pozPioni[0, 5].y = 1.75f; ;
        pozPioni[0, 5].z = pozPioni[0, 3].z;
        #endregion
        #region STANGA1
        pozPioni[1,0] = new Vector3(-215.4f, 1.75f, -149.6f);
        pozPioni[1, 1].x = pozPioni[1, 0].x + hProp / 5;
        pozPioni[1, 1].y = 1.75f;
        pozPioni[1, 1].z = pozPioni[1, 0].z;

        pozPioni[1, 2].x = pozPioni[1, 0].x - hProp / 5;
        pozPioni[1, 2].y = 1.75f;
        pozPioni[1, 2].z = pozPioni[1, 0].z;

        pozPioni[1, 3].x = pozPioni[1, 0].x;
        pozPioni[1, 3].y = 1.75f;
        pozPioni[1, 3].z = pozPioni[1, 0].z - hProp / 5;

        pozPioni[1, 4].x = pozPioni[1, 3].x + hProp / 5;
        pozPioni[1, 4].y = 1.75f;
        pozPioni[1, 4].z = pozPioni[1, 3].z;

        pozPioni[1, 5].x = pozPioni[1, 3].x - hProp / 5;
        pozPioni[1, 5].y = 1.75f;
        pozPioni[1, 5].z = pozPioni[1, 3].z;
        #endregion
        #region STANGA
        for (int i = 2; i < 10; i++)
            for (int j = 0; j < 6; j++)
            {
                pozPioni[i, j] = pozPioni[i - 1, j];
                pozPioni[i, j].z += lProp;
            }
        pozCase[0, 0] = new Vector3(-183, 1.8f, -150.1f);
        pozCase[1, 0] = pozCase[0, 0];
        pozCase[1, 0].z += 2 * lProp;
        pozCase[2, 0] = pozCase[1, 0];
        pozCase[2, 0].z += 3 * lProp;
        pozCase[3, 0] = pozCase[2, 0];
        pozCase[3, 0].z += 2 * lProp;
        pozCase[4, 0] = pozCase[3, 0];
        pozCase[4, 0].z += lProp;
        for (int i = 0; i < 5; i++)
            for (int j = 1; j < 4; j++)
            {
                pozCase[i, j] = pozCase[i, j - 1];
                pozCase[i, j].z -= lProp / 4;
            }
        #endregion
        //pun de mana la astea speciale
        #region VIZITA 
        pozPioni[10, 0] = new Vector3(-236.8f,1.75f,235.2f);
        pozPioni[10, 1] = new Vector3(-236.8f,1.75f,217);
        pozPioni[10, 2] = new Vector3(-236.8f,1.75f,198.3f);
        pozPioni[10, 3] = new Vector3(-185.2f,1.75f,236.1f);
        pozPioni[10, 4] = new Vector3(-208.7f,1.75f,236.1f);
        pozPioni[10, 5] = new Vector3(-222.2f,1.75f,236.1f);
        #endregion
        #region SUS1
        pozPioni[11, 0] = new Vector3(-145.2f, 1.75f, 216.8f);
        pozPioni[11, 1].x = pozPioni[11, 0].x;
        pozPioni[11, 1].y = 1.75f;
        pozPioni[11, 1].z = pozPioni[11, 0].z + hProp / 5;

        pozPioni[11, 2].x = pozPioni[11, 0].x;
        pozPioni[11, 2].y = 1.75f;
        pozPioni[11, 2].z = pozPioni[11, 0].z - hProp / 5;

        pozPioni[11, 3].x = pozPioni[11, 0].x - hProp / 5;
        pozPioni[11, 3].y = 1.75f;
        pozPioni[11, 3].z = pozPioni[11, 0].z;

        pozPioni[11, 4].x = pozPioni[11, 3].x;
        pozPioni[11, 4].y = 1.75f;
        pozPioni[11, 4].z = pozPioni[11, 3].z + hProp / 5;

        pozPioni[11, 5].x = pozPioni[11, 3].x;
        pozPioni[11, 5].y = 1.75f;
        pozPioni[11, 5].z = pozPioni[11, 3].z - hProp / 5;
        #endregion
        #region SUS
        for (int i=12;i<20;i++)
            for (int j=0;j<6;j++)
            {
                pozPioni[i, j] = pozPioni[i - 1, j];
                pozPioni[i, j].x += lProp;
            }
        pozCase[5, 0] = new Vector3(-150.2f, 1.8f, 182.9f);
        pozCase[6, 0] = pozCase[5, 0];
        pozCase[6, 0].x += 2 * lProp;
        pozCase[7, 0] = pozCase[6, 0];
        pozCase[7, 0].x += lProp;
        pozCase[8, 0] = pozCase[7, 0];
        pozCase[8, 0].x += 2 * lProp;
        pozCase[9, 0] = pozCase[8, 0];
        pozCase[9, 0].x += 2 * lProp;
        pozCase[10, 0] = pozCase[9, 0];
        pozCase[10, 0].x += lProp;
        for (int i = 5; i < 11; i++)
            for (int j = 1; j < 4; j++)
            {
                pozCase[i, j] = pozCase[i, j - 1];
                pozCase[i, j].x -= lProp / 4;
            }
        #endregion
        #region PARCARE
        pozPioni[20, 0].x = marimeTabla / 2 - hProp / 2;
        pozPioni[20, 0].y = 1.75f;
        pozPioni[20, 0].z = marimeTabla / 2 - hProp / 2 - 10f;

        pozPioni[20, 1].x = pozPioni[20, 0].x - hProp / 4;
        pozPioni[20, 1].y = 1.75f; ;
        pozPioni[20, 1].z = pozPioni[20, 0].z;

        pozPioni[20, 2].x = pozPioni[20, 0].x + hProp / 4;
        pozPioni[20, 2].y = 1.75f; ;
        pozPioni[20, 2].z = pozPioni[20, 0].z;

        pozPioni[20, 3].x = pozPioni[20, 0].x;
        pozPioni[20, 3].y = 1.75f; ;
        pozPioni[20, 3].z = pozPioni[20, 0].z + hProp / 4;

        pozPioni[20, 4].x = pozPioni[20, 3].x - hProp / 4;
        pozPioni[20, 4].y = 1.75f; ;
        pozPioni[20, 4].z = pozPioni[20, 3].z;

        pozPioni[20, 5].x = pozPioni[20, 3].x + hProp / 4;
        pozPioni[20, 5].y = 1.75f; ;
        pozPioni[20, 5].z = pozPioni[20, 3].z;
        #endregion
        #region DREAPTA1
        pozPioni[21, 0] = new Vector3(216.7f, 1.75f, 147.6f);
        pozPioni[21, 1].x = pozPioni[21, 0].x - hProp / 5;
        pozPioni[21, 1].y = 1.75f;
        pozPioni[21, 1].z = pozPioni[21, 0].z;

        pozPioni[21, 2].x = pozPioni[21, 0].x + hProp / 5;
        pozPioni[21, 2].y = 1.75f;
        pozPioni[21, 2].z = pozPioni[21, 0].z;

        pozPioni[21, 3].x = pozPioni[21, 0].x;
        pozPioni[21, 3].y = 1.75f;
        pozPioni[21, 3].z = pozPioni[21, 0].z + hProp / 5;

        pozPioni[21, 4].x = pozPioni[21, 3].x - hProp / 5;
        pozPioni[21, 4].y = 1.75f;
        pozPioni[21, 4].z = pozPioni[21, 3].z;

        pozPioni[21, 5].x = pozPioni[21, 3].x + hProp / 5;
        pozPioni[21, 5].y = 1.75f;
        pozPioni[21, 5].z = pozPioni[21, 3].z;

        #endregion
        #region DREAPTA
        for (int i=22;i<30;i++)
            for (int j=0;j<6;j++)
            {
                pozPioni[i, j] = pozPioni[i - 1, j];
                pozPioni[i, j].z -= lProp;
            }
        pozCase[11, 0] = new Vector3(182.5f, 1.8f, 150);
        pozCase[12, 0] = pozCase[11, 0];
        pozCase[12, 0].z -= 2 * lProp;
        pozCase[13, 0] = pozCase[12, 0];
        pozCase[13, 0].z -= lProp;
        pozCase[14, 0] = pozCase[13, 0];
        pozCase[14, 0].z -= 2 * lProp;
        pozCase[15, 0] = pozCase[14, 0];
        pozCase[15, 0].z -= lProp;
        pozCase[16, 0] = pozCase[15, 0];
        pozCase[16, 0].z -= 2 * lProp;
        for (int i = 11; i < 17; i++)
            for (int j = 1; j < 4; j++)
            {
                pozCase[i, j] = pozCase[i, j - 1];
                pozCase[i, j].z += lProp / 4;
            }
        #endregion
        #region MERGI INCHISOARE
        pozPioni[30, 0].x = marimeTabla / 2 - hProp / 2 - 10f;
        pozPioni[30, 0].y = 1.75f;
        pozPioni[30, 0].z = -marimeTabla / 2 + hProp / 2;
        #endregion
        #region JOS1
        pozPioni[31, 0] = new Vector3(146.1f, 1.75f, -216.8f);
        pozPioni[31, 1].x = pozPioni[31, 0].x;
        pozPioni[31, 1].y = 1.75f;
        pozPioni[31, 1].z = pozPioni[31, 0].z - hProp / 5;

        pozPioni[31, 2].x = pozPioni[31, 0].x;
        pozPioni[31, 2].y = 1.75f;
        pozPioni[31, 2].z = pozPioni[31, 0].z + hProp / 5;

        pozPioni[31, 3].x = pozPioni[31, 0].x + hProp / 5;
        pozPioni[31, 3].y = 1.75f;
        pozPioni[31, 3].z = pozPioni[31, 0].z;

        pozPioni[31, 4].x = pozPioni[31, 3].x;
        pozPioni[31, 4].y = 1.75f;
        pozPioni[31, 4].z = pozPioni[31, 3].z - hProp / 5;

        pozPioni[31, 5].x = pozPioni[31, 3].x;
        pozPioni[31, 5].y = 1.75f;
        pozPioni[31, 5].z = pozPioni[31, 3].z + hProp / 5;
        #endregion
        #region JOS
        for (int i=32;i<40;i++)
            for (int j=0;j<6;j++)
            {
                pozPioni[i, j] = pozPioni[i - 1, j];
                pozPioni[i, j].x -= lProp;
            }
        pozCase[17, 0] = new Vector3(150.4f, 1.8f, -182.2f);
        pozCase[18, 0] = pozCase[17, 0];
        pozCase[18, 0].x -= lProp;
        pozCase[19, 0] = pozCase[18, 0];
        pozCase[19, 0].x -= 2 * lProp;
        pozCase[20, 0] = pozCase[19, 0];
        pozCase[20, 0].x -= 3 * lProp;
        pozCase[21, 0] = pozCase[20, 0];
        pozCase[21, 0].x -= 2 * lProp;
        for (int i = 17; i < 22; i++)
            for (int j = 1; j < 4; j++)
            {
                pozCase[i, j] = pozCase[i, j - 1];
                pozCase[i, j].x += lProp / 4;
            }
        #endregion
        #region INCHISOARE
        pozPioni[40, 0] = new Vector3(-200.7f,1.75f,227.9f);
        pozPioni[40, 1].x = pozPioni[40, 0].x + hProp / 5;
        pozPioni[40, 1].y = 1.75f;
        pozPioni[40, 1].z = pozPioni[40, 0].z;

        pozPioni[40, 2].x = pozPioni[40, 0].x - hProp / 5;
        pozPioni[40, 2].y = 1.75f;
        pozPioni[40, 2].z = pozPioni[40, 0].z;

        pozPioni[40, 3].x = pozPioni[40, 0].x;
        pozPioni[40, 3].y = 1.75f;
        pozPioni[40, 3].z = pozPioni[40, 0].z - hProp / 3;

        pozPioni[40, 4].x = pozPioni[40, 3].x + hProp / 5;
        pozPioni[40, 4].y = 1.75f;
        pozPioni[40, 4].z = pozPioni[40, 3].z;

        pozPioni[40, 5].x = pozPioni[40, 3].x - hProp / 5;
        pozPioni[40, 5].y = 1.75f;
        pozPioni[40, 5].z = pozPioni[40, 3].z;
        #endregion
    }

    void InitSanse()
    {
        for (int i = 0; i < 15; i++)
            listaSansa.Add(i);
        for (int i = 0; i < 14; i++)
            listaCufar.Add(i);
        amesteca(listaSansa);
        amesteca(listaCufar);
        initTxt();
    }

    // Update is called once per frame
    void Update()
    {
        if (endgame == false)
        {
            if (Input.GetKey(KeyCode.Escape)) UImagic.showERR = 9;
            // players[1].money = 1;

            if (Player.nrPlayers > 0 && players[laRand].pierdut == true) gataTura();
            if (Player.nrPlayers > 0 && players[laRand].inchisoare && !turaPuscarie && !players[laRand].platit50)
                buton50.SetActive(true);
            else if (Player.nrPlayers > 0 && !players[laRand].inchisoare && !turaPuscarie && !players[laRand].platit50)
                buton50.SetActive(false);
            if ((AruncaZar1.aruncat && AruncaZar2.aruncat) && AruncaZar1.vitezaZar == Vector3.zero && AruncaZar2.vitezaZar == Vector3.zero)
            {
                AruncaZar1.aruncat = false;
                AruncaZar2.aruncat = false;
                if (players[laRand].inchisoare)
                {
                    turaPuscarie = true;
                    StartCoroutine(turaInchisoare());
                }
                else
                    StartCoroutine(tura());
            }
        }
        else
        {
            //
        }
    }

    IEnumerator tura()
    {
        if (players[laRand].pierdut == true)
        {
            //gataTura();
        }
        else
        {
            if (terminaTura.interactable == false)
            {
                if (seJoaca)
                    yield break;

                seJoaca = true;

                //mutare
                if (!dinInchisoare)
                {
                    while (AfisareZar.nrZar == 0 || AruncaZar1.vitezaZar != Vector3.zero || AruncaZar2.vitezaZar != Vector3.zero)
                        yield return new WaitForSeconds(0.1f);
                    Time.timeScale = 1f;
                }
                yield return new WaitForSeconds(0.5f);
                if (AfisareZar.nrZar1 == AfisareZar.nrZar2)
                {
                    nrduble++;
                }
                if (nrduble == 3)
                    yield return StartCoroutine(inchisoare(players[laRand]));
                if (players[laRand].poz > 25)
                    StartCoroutine(inchisoare(players[laRand]));
                int aux = players[laRand].poz;
                for (int i = 0; i < AfisareZar.nrZar && !players[laRand].inchisoare; i++)
                {
                    nrPlayers[aux]--;
                    if (aux == 40)
                        aux = 10;
                    if ((aux + 1) % 10 == 0 && aux + 1 != 10)
                        players[laRand].pion.transform.rotation = Quaternion.Euler(-90, (aux + 1) % 40 / 10 * 90, 0);
                    else if (aux + 1 == 10)
                    {
                        if (nrPlayers[10] >= 3)
                            players[laRand].pion.transform.rotation = Quaternion.Euler(-90, 90, 0);
                    }
                    else if (aux + 1 == 11)
                        players[laRand].pion.transform.rotation = Quaternion.Euler(-90, 90, 0);
                    yield return StartCoroutine(misca(players[laRand].pion, players[laRand].pion.transform.position, pozPioni[(aux + 1) % 40, nrPlayers[(aux + 1) % 40]]));
                    nrPlayers[(aux + 1) % 40]++;
                    aux = (aux + 1) % 40;
                    if (aux == 0)
                        banca.plata(players[laRand], 200);
                }
                players[laRand].poz = aux;
                //chirie
                if (aux == 0 || aux == 10 || aux == 20 || aux == 40) //nimic
                    aux = aux;
                else if (aux == 30) //inchisoare
                {
                    yield return StartCoroutine(inchisoare(players[laRand]));
                }
                else if (aux % 10 == 5)
                {
                    if (gari[aux / 10].ownedByBank == true)
                    {
                        setPreviewProp.crtID = gari[aux / 10].SID;
                        crtP = aux / 10;
                        crtTip = "gara";
                        inBuyScreen = true;
                    }
                    else if (gari[aux / 10].owner.id != players[laRand].id && gari[aux / 10].ipotecat == false)
                    {
                        int nrgari = 0;
                        foreach (Proprietate2 g in gari)
                            if (g.owner.id == gari[aux / 10].owner.id && gari[aux / 10].ipotecat == false)
                                nrgari++;
                        players[laRand].plata(gari[aux / 10].owner, 25 * (1 << (nrgari - 1)));
                    }
                }
                else if (aux == 12 || aux == 28)
                {
                    if (util[aux / 27].ownedByBank == true)
                    {
                        setPreviewProp.crtID = util[aux / 27].SID;
                        crtP = aux / 27;
                        crtTip = "util";
                        inBuyScreen = true;
                    }
                    else if (util[aux / 27].owner.id != players[laRand].id && util[aux / 27].ipotecat == false)
                    {
                        while (AfisareZar.nrZar == 0 || AruncaZar1.vitezaZar != Vector3.zero || AruncaZar2.vitezaZar != Vector3.zero)
                            yield return new WaitForSeconds(0.1f);
                        Time.timeScale = 1f;
                        if (util[0].owner == util[1].owner && util[0].ipotecat == false && util[1].ipotecat == false)
                            players[laRand].plata(util[aux / 27].owner, AfisareZar.nrZar * 10);
                        else
                            players[laRand].plata(util[aux / 27].owner, AfisareZar.nrZar * 4);
                    }
                }
                else if (notsansa(aux) == true && notTaxa(aux) == true)
                {
                    if (props[aux].ownedByBank == true)
                    {
                        setPreviewProp.crtID = props[aux].SID;
                        crtP = aux;
                        crtTip = "prop";
                        Debug.Log(props[aux].SID);
                        inBuyScreen = true;
                    }
                    else if (props[aux].owner.id != players[laRand].id && props[aux].ipotecat == false)
                        players[laRand].plata(props[aux].owner, props[aux].chirie[props[aux].numarCase]);
                }
                else
                {
                    if (notTaxa(aux) == true)
                    {
                        Debug.Log("Vlad nu stie unity");
                        if (aux == 7 || aux == 22 || aux == 36)
                            yield return StartCoroutine(sansa(players[laRand]));
                        else
                            yield return StartCoroutine(cufar(players[laRand]));
                    }
                    else
                    {
                        if (aux == 4) players[laRand].plata(banca, 200);
                        else players[laRand].plata(banca, 100);
                    }
                }
                //trade/end turn
                if (nrduble == pre || players[laRand].inchisoare)
                {
                    //laRand = (laRand + 1) % Player.nrPlayers;
                    terminaTura.interactable = true;
                    daCuZaru.interactable = false;
                    nrduble = pre = 0;
                }
                pre = nrduble;
                seJoaca = false;
            }
        }
    }

    void amesteca(List<int> l)
    {
        int n = l.Count;

        for (int i = n - 1; i >= 0; i--)
        {
            int k = Random.Range(0, i);
            int aux = l[i];
            l[i] = l[k];
            l[k] = aux;
        }
    }

    public IEnumerator sansa(Player p)
    {
        int i;
        int nr, aux;

        nr = listaSansa[pozSansa];
        pozSansa = (pozSansa + 1) % 15;
        setPreviewProp.crtID = nr.ToString();
        yield return new WaitForSeconds(2f);
        while (previewProp.activeSelf == true)
            yield return new WaitForSeconds(0.1f);
        switch (nr)
        {
            case 0: p.plata(banca, 15); break; //-15
            case 1: //mergi cea mai apropiata gara + chirie dubla
                for (i = p.poz + 1; i % 10 != 5; i++) ;
                i %= 40;
                if (i < p.poz)
                    banca.plata(p, 200);
                deplasare(p, i);

                break;
            case 2: //inchisoare
                yield return StartCoroutine(inchisoare(p));
                break;
            case 3: //mergi prima gara
                if (5 < p.poz)
                    banca.plata(p, 200);
                deplasare(p, 5);
                break;
            case 4: //mergi a 3 rosie
                if (23 < p.poz)
                    banca.plata(p, 200);
                deplasare(p, 24);
                break;
            case 5: //mergi 3 inapoi
                deplasare(p, p.poz - 3);
                break;
            case 6: //+150
                banca.plata(p, 150);
                break;
            case 7: //reparatii 25/100
                int suma = 0;
                foreach (Proprietate x in props)
                {
                    if (x.owner.id == p.id)
                    {
                        if (x.numarCase == 5)
                            suma += 100;
                        else suma += x.numarCase * 25;
                    }
                }
                p.plata(banca, suma);
                break;
            case 8: //+50
                banca.plata(p, 50);
                break;
            case 9: //platesti 50 la fiecare player
                foreach (Player x in players)
                    if (x.id != p.id)
                        p.plata(x, 50);
                break;
            case 10: //mergi start
                banca.plata(p, 200);
                deplasare(p, 0);
                break;
            case 11: //mergi la a 2 albastru inchis
                deplasare(p, 39);
                break;
            case 12: //mergi cea mai apropiata gara + chirie dubla
                for (i = p.poz + 1; i % 10 != 5; i++) ;
                i %= 40;
                if (i < p.poz)
                    banca.plata(p, 200);
                deplasare(p, i);
                break;
            case 13: //mergi cea mai apropiata utilitate, dai cu 1 zar, platesti 10x
                if (p.poz > 12 && p.poz < 28)
                    i = 28;
                else i = 12;
                if (i < p.poz)
                    banca.plata(p, 200);
                deplasare(p, i);
                break;
            case 14: //mergi la prima roz
                if (11 < p.poz)
                    banca.plata(p, 200);
                deplasare(p, 11);
                break;
        }
        aux = p.poz;
        if (aux == 0 || aux == 10 || aux == 20 || aux == 40) //nimic
            aux = aux;
        else if (aux % 10 == 5)
        {
            if (gari[aux / 10].ownedByBank == true)
            {
                setPreviewProp.crtID = gari[aux / 10].SID;
                crtP = aux / 10;
                crtTip = "gara";
                inBuyScreen = true;
            }
            else if (gari[aux / 10].owner.id != players[laRand].id && gari[aux / 10].ipotecat == false)
            {
                int nrgari = 0;
                foreach (Proprietate2 g in gari)
                    if (g.owner.id == gari[aux / 10].owner.id && gari[aux / 10].ipotecat == false)
                        nrgari++;
                players[laRand].plata(gari[aux / 10].owner, 25 * (1 << (nrgari)));
            }
        }
        else if (aux == 12 || aux == 28)
        {
            if (util[aux / 27].ownedByBank == true)
            {
                setPreviewProp.crtID = util[aux / 27].SID;
                crtP = aux / 27;
                crtTip = "util";
                inBuyScreen = true;
            }
            else if (util[aux / 27].owner.id != players[laRand].id && util[aux / 27].ipotecat == false)
            {
                while (AfisareZar.nrZar == 0 || AruncaZar1.vitezaZar != Vector3.zero || AruncaZar2.vitezaZar != Vector3.zero)
                    yield return new WaitForSeconds(0.1f);
                Time.timeScale = 1f;
                if (util[0].owner == util[1].owner && util[0].ipotecat == false && util[1].ipotecat == false)
                    players[laRand].plata(util[aux / 27].owner, AfisareZar.nrZar * 10);
                else
                    players[laRand].plata(util[aux / 27].owner, AfisareZar.nrZar * 4);
            }
        }
        else if (notsansa(aux) == true && notTaxa(aux) == true)
        {
            if (props[aux].ownedByBank == true)
            {
                setPreviewProp.crtID = props[aux].SID;
                crtP = aux;
                crtTip = "prop";
                Debug.Log(props[aux].SID);
                inBuyScreen = true;
            }
            else if (props[aux].owner.id != players[laRand].id && props[aux].ipotecat == false)
                players[laRand].plata(props[aux].owner, props[aux].chirie[props[aux].numarCase]);
        }
        else
        {
            if (notTaxa(aux) == true)
            {
                Debug.Log("Vlad nu stie unity");
                if (aux == 7 || aux == 22 || aux == 36)
                    yield return StartCoroutine(sansa(players[laRand]));
                else
                    yield return StartCoroutine(cufar(players[laRand]));
            }
            else
            {
                if (aux == 4) players[laRand].plata(banca, 200);
                else players[laRand].plata(banca, 100);
            }
        }
    }

    public IEnumerator cufar(Player p)
    {
        int nr;

        nr = listaCufar[pozCufar];
        pozCufar = (pozCufar + 1) % 14;
        setPreviewProp.crtID = (15 + nr).ToString();
        yield return new WaitForSeconds(0.01f);
        switch (nr)
        {
            case 0: //+25
                banca.plata(p, 25);
                break;
            case 1: //reparatii 40/115
                int suma = 0;
                foreach (Proprietate x in props)
                {
                    if (x.owner.id == p.id)
                    {
                        if (x.numarCase == 5)
                            suma += 100;
                        else suma += x.numarCase * 25;
                    }
                }
                p.plata(banca, suma);
                break;
            case 2: //primesti 10 de la fiecare player
                foreach (Player x in players)
                    if (x.id != p.id)
                        x.plata(p, 10);
                break;
            case 3: //inchisoare
                yield return StartCoroutine(inchisoare(p));
                break;
            case 4: //+100
                banca.plata(p, 100);
                break;
            case 5: //-50
                p.plata(banca, 50);
                break;
            case 6: //-50
                p.plata(banca, 50);
                break;
            case 7: //+20
                banca.plata(p, 20);
                break;
            case 8: //+50
                banca.plata(p, 50);
                break;
            case 9: //-100
                p.plata(banca, 100);
                break;
            case 10: //+10
                banca.plata(p, 10);
                break;
            case 11: //+100
                banca.plata(p, 100);
                break;
            case 12: //+100
                banca.plata(p, 100);
                break;
            case 13: //mergi start
                banca.plata(p, 200);
                deplasare(p, 0);
                break;
        }
    }

    void deplasare(Player p, int i)
    {
        nrPlayers[p.poz]--;
        StartCoroutine(misca(p.pion, p.pion.transform.position, pozPioni[i, nrPlayers[i]]));
        p.pion.transform.rotation = Quaternion.Euler(-90, i / 10 * 90, 0);
        nrPlayers[i]++;
        p.poz = i;
    }

    void initTxt()
    {
        //sanse
        scTxt.Add("Ai depasit limita de viteza. Plateste o amenda de 15 lei.");
        scTxt.Add("Mergi la cea mai apropiata gara.\n\nDaca nu este detinuta de un jucator o poti cumpara de la banca.\n\nDaca un jucator o detine plateste chirie dubla");
        scTxt.Add("Ai fost prins facand evaziune fiscala. Mergi la inchisoare.");
        scTxt.Add("Mergi la " + GetComponent<creare_tabla>().names["gara1"]);
        scTxt.Add("Mergi la " + GetComponent<creare_tabla>().names["rosu1"]);
        scTxt.Add("Ai alunecat pe o coaja de banana. Mergi 3 pozitii inapoi");
        scTxt.Add("Ai castigat la loto. Colecteaza 150 de lei.");
        scTxt.Add("A venit controlul ISU. Plateste 25 de lei pentru fiecare casa construita si 100 de lei pentru fiecare hotel");
        scTxt.Add("Ai gasit niste bani pe strada. Colecteaza 50 de lei");
        scTxt.Add("Ai pierdut un pariu. Plateste 50 de lei fiecarui jucator");
        scTxt.Add("Mergi la Start");
        scTxt.Add("Mergi la " + GetComponent<creare_tabla>().names["albastru1"]);
        scTxt.Add("Mergi la cea mai apropiata gara.\n\nDaca nu este detinuta de un jucator o poti cumpara de la banca.\n\nDaca un jucator o detine plateste chirie dubla");
        scTxt.Add("Mergi la cea mai apropiata utilitate.");
        scTxt.Add("Mergi la " + GetComponent<creare_tabla>().names["roz3"]);

        //cufere
        scTxt.Add("Ai castigat un concurs de frumusete. Colecteaza 25 de lei.");
        scTxt.Add("A venit controlul ISU. Plateste 40 de lei pentru fiecare casa construita si 115 de lei pentru fiecare hotel.");
        scTxt.Add("Este ziua ta. Coleacteaza 10 lei de la fiecare jucator.");
        scTxt.Add("Ai fost prins facand evaziune fiscala. Mergi la inchisoare.");
        scTxt.Add("Ai primit un bonus la salariu. Colecteaza 100 de lei.");
        scTxt.Add("Ai pierdut 50 de lei. Ce pacat.");
        scTxt.Add("Ai circulat cu autobuzul fara bilet. Plateste o amenda de 50 de lei.");
        scTxt.Add("Ai castigat o tombola. Colecteaza 20 de lei.");
        scTxt.Add("Ai primit cadou de craciun. Colecteaza 50 de lei.");
        scTxt.Add("Ti-ai pierdut portofelul. Pierzi 100 de lei.");
        scTxt.Add("Ai castigat la carti. Colecteaza 10 lei.");
        scTxt.Add("Ai primit premiul pentru antreprenorul lunii. Colecteaza 100 de lei.");
        scTxt.Add("Ai primit o donatie din partea unei fundatii. Colecteaza 100 de lei.");
        scTxt.Add("Mergi la Start");
    }

    bool notsansa(int x)
    {
        return !(x == 2 || x == 7 || x == 17 || x == 22 || x == 33 || x == 36);
    }

    bool notTaxa(int x)
    {
        return !(x == 4 || x == 38);
    }

    public void gataTura()
    {
        if (nextelig())
        {
            terminaTura.interactable = false;
            daCuZaru.interactable = true;
            laRand = (laRand + 1) % Player.nrPlayers;
            UImagic.upList = true;
            int nr = 0;
            string nume = null;
            foreach (Player p in players)
            {
                if (p.pierdut == false)
                {
                    nr++;
                    nume = p.nume;
                }
            }
            if (nr == 1)
            {
                UImagic.winnerplayer = nume;
                UImagic.showERR = 8;
                endgame = true;
                fireworks.SetActive(true);
                ExitGame.SetActive(true);
		        daCuZaru.interactable = false;
                terminaTura.interactable = false;
            }
            turaPuscarie = false;
        }
    }

    bool nextelig()
    {
        if (players[laRand].money < 0 && players[laRand].pierdut == false)
        {
            if (sigurok == false)
            {
                UImagic.showERR = 2;
                sigurok = true;
                return false;
            }
            else
            {
                players[laRand].lost();
                sigurok = false;
                return true;
            }
        }
        else return true;
    }

    public static void offBuyScreen()
    {
        inBuyScreen = false;
        setPreviewProp.iesi = true;
    }

    public void urascUnity()
    {
        inBuyScreen = false;
    }

    IEnumerator turaInchisoare()
    {
        while ((AfisareZar.nrZar == 0 || AruncaZar1.vitezaZar != Vector3.zero || AruncaZar2.vitezaZar != Vector3.zero) && !players[laRand].platit50)
        {
            buton50.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        Time.timeScale = 1f;
        if (players[laRand].platit50)
        {
            players[laRand].inchisoare = false;
            yield return StartCoroutine(tura());
        }
        else
        {
            if (AfisareZar.nrZar1 == AfisareZar.nrZar2)
            {
                dinInchisoare = true;
                players[laRand].inchisoare = false;
                yield return StartCoroutine(tura());
                dinInchisoare = false;
            }
            else
            {
                players[laRand].dubleInchisoare++;
                if (players[laRand].dubleInchisoare == 3)
                {
                    dinInchisoare = true;
                    players[laRand].inchisoare = false;
                    plata50();
                    yield return StartCoroutine(tura());
                    dinInchisoare = false;
                }
                else
                {
                    daCuZaru.interactable = false;
                    terminaTura.interactable = true;

                }
            }
        }
    }

    public void plata50()
    {
        players[laRand].plata(banca, 50);
        players[laRand].platit50 = true;
        buton50.SetActive(false);
    }

    public static IEnumerator misca(GameObject pion, Vector3 poz1, Vector3 poz2)
    {
        if (seMisca)
            yield break;

        float x, z, f, r, pas, initx = pion.transform.position.x, inity = 1.75f, initz = pion.transform.position.z;
        Vector3 newPos = new Vector3();

        seMisca = true;
        //pion.GetComponent<Rigidbody>().useGravity = false;
        if (Mathf.Abs(poz1.x - poz2.x) < 0.01f)
        {
            float xcentru = (poz1.x + poz2.x) / 2, zcentru = (poz1.z + poz2.z) / 2;
            if (poz1.z < poz2.z)
            {
                r = (poz2.z - poz1.z) / 2;
                if (r < 5 * lProp)
                    pas = r / 20f;
                else pas = r / 40f;
                for (z = poz1.z; z <= poz2.z; z += pas)
                {
                    yield return new WaitForSeconds(0.01f);
                    newPos.x = poz1.x;
                    newPos.z = z;
                    if (r * r - (z - zcentru) * (z - zcentru) > 0)
                        f = Mathf.Sqrt(r * r - (z - zcentru) * (z - zcentru));
                    else f = 0;
                    newPos.y = inity + f;
                    pion.transform.position = newPos;
                }
            }
            else
            {
                r = (poz1.z - poz2.z) / 2;
                if (r < 5 * lProp)
                    pas = r / 20f;
                else pas = r / 40f;
                for (z = poz1.z; z >= poz2.z; z -= pas)
                {
                    yield return new WaitForSeconds(0.01f);
                    newPos.x = poz1.x;
                    newPos.z = z;
                    if (r * r - (z - zcentru) * (z - zcentru) > 0)
                        f = Mathf.Sqrt(r * r - (z - zcentru) * (z - zcentru));
                    else f = 0;
                    newPos.y = inity + f;
                    pion.transform.position = newPos;
                }
            }
        }
        else if (Mathf.Abs(poz1.z - poz2.z) < 0.01f)
        {
            float xcentru = (poz1.x + poz2.x) / 2, zcentru = (poz1.z + poz2.z) / 2;
            if (poz1.x < poz2.x)
            {
                r = (poz2.x - poz1.x) / 2;
                if (r < 5 * lProp)
                    pas = r / 20f;
                else pas = r / 40f;
                for (x = poz1.x; x <= poz2.x; x += pas)
                {
                    yield return new WaitForSeconds(0.01f);
                    newPos.x = x;
                    newPos.z = poz1.z;
                    if (r * r - (x - xcentru) * (x - xcentru) > 0)
                        f = Mathf.Sqrt(r * r - (x - xcentru) * (x - xcentru));
                    else f = 0;
                    newPos.y = inity + f;
                    pion.transform.position = newPos;
                }
            }
            else
            {
                r = (poz1.x - poz2.x) / 2;
                if (r < 5 * lProp)
                    pas = r / 20f;
                else pas = r / 40f;
                for (x = poz1.x; x >= poz2.x; x -= pas)
                {
                    yield return new WaitForSeconds(0.01f);
                    newPos.x = x;
                    newPos.z = poz1.z;
                    if (r * r - (x - xcentru) * (x - xcentru) > 0)
                        f = Mathf.Sqrt(r * r - (x - xcentru) * (x - xcentru));
                    else f = 0;
                    newPos.y = inity + f;
                    pion.transform.position = newPos;
                }
            }
        }
        else
        {
            //pentru a afla fiecare x si z pentru semicerc calculam ecuatia dreptei intre poz1 si poz2
            float m = (poz2.z - poz1.z) / (poz2.x - poz1.x);
            float n = poz1.z - m * poz1.x;

            //folosim ecuatia sferei pentru a face un semicerc intre poz1 si poz2 (x^2+y^2+z^2=r^2)
            //y = f(x,z) = sqrt(r^2-x^2-z^2)
            float dif1 = poz2.x - poz1.x, dif2 = poz2.z - poz1.z;
            r = Mathf.Sqrt((dif1 * dif1 + dif2 * dif2)) / 2;
            float xcentru = (poz1.x + poz2.x) / 2, zcentru = (poz1.z + poz2.z) / 2;
            if (poz1.x < poz2.x)
            {
                if (poz2.x-poz1.x < 5*lProp)
                    pas = (poz2.x - poz1.x) / 40f;
                else pas = (poz2.x - poz1.x) / 80f;
                for (x = poz1.x; x <= poz2.x; x += pas)
                {
                    newPos.x = x;
                    z = newPos.z = m * x + n;
                    if (r * r - (x - xcentru) * (x - xcentru) - (z - zcentru) * (z - zcentru) > 0)
                        f = Mathf.Sqrt(r * r - (x - xcentru) * (x - xcentru) - (z - zcentru) * (z - zcentru));
                    else f = 0;
                    newPos.y = inity + f;
                    yield return new WaitForSeconds(0.01f);
                    pion.transform.position = newPos;
                }
            }
            else
            {
                if (poz1.x - poz2.x < 5 * lProp)
                    pas = (poz1.x - poz2.x) / 40f;
                else pas = (poz1.x - poz2.x) / 80f;
                for (x = poz1.x; x >= poz2.x; x -= pas)
                {
                    newPos.x = x;
                    z = newPos.z = m * x + n;
                    if (r * r - (x - xcentru) * (x - xcentru) - (z - zcentru) * (z - zcentru) > 0)
                        f = Mathf.Sqrt(r * r - (x - xcentru) * (x - xcentru) - (z - zcentru) * (z - zcentru));
                    else f = 0;
                    newPos.y = inity + f;
                    yield return new WaitForSeconds(0.01f);
                    pion.transform.position = newPos;
                }
            }
        }
        pion.transform.position = poz2;
        //pion.GetComponent<Rigidbody>().useGravity = true;
        seMisca = false;
    }

    public IEnumerator inchisoare(Player p)
    {
        p.inchisoare = true;
        nrPlayers[p.poz]--;
        p.pion.transform.rotation = Quaternion.Euler(-90, 0, 0);
        yield return StartCoroutine(misca(p.pion, p.pion.transform.position, pozPioni[40, nrPlayers[40]]));
        nrPlayers[40]++;
        players[laRand].poz = 40;
        p.dubleInchisoare = 0;
        p.platit50 = false;
    }

    public void curataTrade()
    {
        Transform[] g1 = tradePropsST1.GetComponentsInChildren<Transform>();
        Transform[] g2 = tradePropsDR1.GetComponentsInChildren<Transform>();
        Transform[] g3 = tradePropsST2.GetComponentsInChildren<Transform>();
        Transform[] g4 = tradePropsDR2.GetComponentsInChildren<Transform>();
        foreach (Transform g in g1)
        {
            if (g.GetComponent<Tradebutton>() != null) g.GetComponent<Tradebutton>().selectat = false;
        }
        foreach(Transform g in g2)
        {
            if (g.GetComponent<Tradebutton>() != null) g.GetComponent<Tradebutton>().selectat = false;
        }
        foreach (Transform g in g3)
        {
            if (g.GetComponent<Tradebutton>() != null) g.GetComponent<Tradebutton>().selectat = false;
        }
        foreach (Transform g in g4)
        {
            if (g.GetComponent<Tradebutton>() != null) g.GetComponent<Tradebutton>().selectat = false;
        }

        Image[] iT1 = tradeST.GetComponentsInChildren<Image>();
        Image[] iT2 = tradeDR.GetComponentsInChildren<Image>();
        foreach(Image i in iT1)
        {
            i.GetComponent<Outline>().enabled = false;
            i.GetComponentInChildren<Text>().text = "";
        }
        foreach (Image i in iT2)
        {
            i.GetComponent<Outline>().enabled = false;
            i.GetComponentInChildren<Text>().text = "";
        }

        ddST.GetComponent<Dropdown>().value = 0;
        ddDR.GetComponent<Dropdown>().value = 0;
        baniST.GetComponentInChildren<InputField>().text = "";
        baniDR.GetComponentInChildren<InputField>().text = "";
    }

    public void IESIDINJOC()
    {
        Application.Quit();
    }
}
