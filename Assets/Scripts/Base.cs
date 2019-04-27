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
    public static int[] nrPlayers = new int[40];
    public static int laRand = 0;
    static bool seMisca = false;

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
        InitProps();
        InitPoz();/*
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
        foreach (Proprietate p in props)
        {
            p.SetOwner(banca);
        }
    }

    //initializare proprietati
    void InitProps()
    {
        Proprietate nein = new Proprietate("nu", 0, 0, 0, 0, null);//adaug null pe pozitiile unde nu am proprietati
        #region MARO
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["maro2"], preturi[0], 30, 50, 0, "maro"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["maro1"], preturi[1], 30, 50, 1, "maro"));
        #endregion
        props.Add(nein);
        props.Add(nein);
        #region BLEU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["bleu3"], preturi[2], 50, 50, 2, "bleu"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["bleu2"], preturi[3], 50, 50, 3, "bleu"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["bleu1"], preturi[4], 60, 50, 4, "bleu"));
        #endregion
        props.Add(nein);
        #region ROZ
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["roz3"], preturi[5], 70, 100, 5, "roz"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["roz2"], preturi[6], 70, 100, 6, "roz"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["roz1"], preturi[7], 80, 100, 7, "roz"));
        #endregion
        props.Add(nein);
        #region PORTOCALIU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["portocaliu3"], preturi[8], 90, 100, 8, "portocaliu"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["portocaliu2"], preturi[9], 90, 100, 9, "portocaliu"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["portocaliu1"], preturi[10], 100, 100, 10, "portocaliu"));
        #endregion
        props.Add(nein);
        #region ROSU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["rosu3"], preturi[11], 110, 150, 11, "rosu"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["rosu2"], preturi[12], 110, 150, 12, "rosu"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["rosu1"], preturi[13], 120, 150, 13, "rosu"));
        #endregion
        props.Add(nein);
        #region GALBEN
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["galben3"], preturi[14], 130, 150, 14, "galben"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["galben2"], preturi[15], 130, 150, 15, "galben"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["galben1"], preturi[16], 140, 150, 16, "galben"));
        #endregion
        props.Add(nein);
        #region VERDE
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["verde3"], preturi[17], 150, 200, 17, "verde"));
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["verde2"], preturi[18], 150, 200, 18, "verde"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["verde1"], preturi[19], 160, 200, 19, "verde"));
        #endregion
        props.Add(nein);
        props.Add(nein);
        #region ALBASTRU
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["albastru2"], preturi[20], 175, 200, 20, "albastru"));
        props.Add(nein);
        props.Add(new Proprietate(GetComponent<creare_tabla>().names["albastru1"], preturi[21], 200, 200, 21, "albastru"));
        #endregion
        int k = 0;
        for (int i = 0; i < 22;)
        {
            if (props[k].nume != "nu")
            {
                for (int j = 0; j < 6; j++)
                    props[k].chirie[j] = chirii[i * 6 + j];
                i++;
            }
            k++;
        }
        #region UTILITATI
        util.Add(new Proprietate2(GetComponent<creare_tabla>().names["util1"], preturi[22], 75, 0));
        util.Add(new Proprietate2(GetComponent<creare_tabla>().names["util2"], preturi[22], 75, 1));
        #endregion
        #region GARI
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara1"], preturi[23], 100, 0));
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara2"], preturi[23], 100, 1));
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara3"], preturi[23], 100, 2));
        gari.Add(new Proprietate2(GetComponent<creare_tabla>().names["gara4"], preturi[23], 100, 3));
        #endregion
    }

    public void InitPlayer()
    {
        string nume = textNume.text;
        peon = Instantiate(modele[pionus.i], pozPioni[0, nrPlayers[0]], Quaternion.Euler(270f, 0f, 0f)) as GameObject;
        peon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        peon.AddComponent<Rigidbody>();
        peon.AddComponent<BoxCollider>();
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
        #endregion
        #region INCHISOARE
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && AruncaZar1.vitezaZar == Vector3.zero && AruncaZar2.vitezaZar == Vector3.zero)
        {
            if (players[laRand].inchisoare)
                StartCoroutine(turaInchisoare());
            else
                StartCoroutine(tura());
        }
    }

    IEnumerator tura()
    {
        int nrduble = 0, pre = 0; ;
        if (seJoaca)
            yield break;

        seJoaca = true;

        //mutare
        while (AfisareZar.nrZar == 0 || AruncaZar1.vitezaZar != Vector3.zero || AruncaZar2.vitezaZar != Vector3.zero)
            yield return new WaitForSeconds(0.1f);
        if (AfisareZar.nrZar1 == AfisareZar.nrZar2)
            nrduble++;
        if (nrduble == 3)
            yield return StartCoroutine(inchisoare(players[laRand]));
        int aux = players[laRand].poz;
        for (int i=0;i<AfisareZar.nrZar && !players[laRand].inchisoare;i++)
        {
            nrPlayers[aux]--;
            if ((aux + 1) % 10 == 0 && aux + 1 != 10)
                players[laRand].pion.transform.rotation = Quaternion.Euler(-90, (aux + 1) % 40 / 10 * 90, 0);
            else if (aux + 1 == 10)
            {
                if (nrPlayers[10] >= 3)
                    players[laRand].pion.transform.rotation = Quaternion.Euler(-90, 90, 0);
            }
            else if (aux + 1 == 11)
                players[laRand].pion.transform.rotation = Quaternion.Euler(-90, 90, 0);
            yield return StartCoroutine(misca(players[laRand].pion,players[laRand].pion.transform.position, pozPioni[(aux + 1) % 40, nrPlayers[(aux + 1) % 40]]));
            nrPlayers[(aux + 1) % 40]++;
            aux = (aux + 1) % 40;
            if (aux == 0)
                banca.plata(players[laRand], 200);
        }
        players[laRand].poz = aux;
        //chirie
        if (aux == 0 || aux == 10 || aux == 20) //nimic
            aux = aux;
        else if (aux == 30) //inchisoare
        {
            yield return StartCoroutine(inchisoare(players[laRand]));
        }
        else if (aux % 10 == 5)
        {
            if (gari[aux/10].owner == banca)
            {
                //pot sa cumpar
            }
            else if (gari[aux/10].owner != players[laRand])
            {
                int nrgari = 0;
                foreach (Proprietate2 g in gari)
                    if (g.owner == gari[aux / 10].owner)
                        nrgari++;
                players[laRand].plata(gari[aux / 10].owner, 25 * (1 << (nrgari - 1)));
            }
        }
        else if (aux == 12 || aux == 18)
        {
            if (util[aux/13].owner == banca)
            {
                //pot sa cumpar
            }
            else if (util[aux/13].owner != players[laRand])
            {
                while (AfisareZar.nrZar == 0 || AruncaZar1.vitezaZar != Vector3.zero || AruncaZar2.vitezaZar != Vector3.zero)
                    yield return new WaitForSeconds(0.1f);
                if (util[0].owner == util[1].owner)
                    players[laRand].plata(util[aux / 13].owner, AfisareZar.nrZar * 10);
                else
                    players[laRand].plata(util[aux / 13].owner, AfisareZar.nrZar * 4);
            }
        }
        else
        {
            if (props[aux].owner == banca)
            {
                //pot sa cumpar
            }
            else if (props[aux].owner != players[laRand])
                players[laRand].plata(props[aux].owner, props[aux].chirie[props[aux].numarCase]);
        }
        //trade/end turn
        if (nrduble == pre)
            laRand = (laRand + 1) % Player.nrPlayers;
        pre = nrduble;
        seJoaca = false;
    }

    IEnumerator turaInchisoare()
    {
        yield return new WaitForSeconds(0.01f);
    }

    public static IEnumerator misca(GameObject pion, Vector3 poz1, Vector3 poz2)
    {
        if (seMisca)
            yield break;

        float x, z, f, r, pas, initx = pion.transform.position.x, inity = 1.75f, initz = pion.transform.position.z;
        Vector3 newPos = new Vector3();

        seMisca = true;
        pion.GetComponent<Rigidbody>().useGravity = false;
        if (poz1.x == poz2.x)
        {
            float xcentru = (poz1.x + poz2.x) / 2, zcentru = (poz1.z + poz2.z) / 2;
            if (poz1.z < poz2.z)
            {
                r = (poz2.z - poz1.z) / 2;
                pas = r / 20f;
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
                pas = r / 20f;
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
        else if (poz1.z == poz2.z)
        {
            float xcentru = (poz1.x + poz2.x) / 2, zcentru = (poz1.z + poz2.z) / 2;
            if (poz1.x < poz2.x)
            {
                r = (poz2.x - poz1.x) / 2;
                pas = r / 20f;
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
                pas = r / 20f;
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
                pas = (poz2.x-poz1.x)/ 40f;
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
                pas = (poz1.x - poz2.x) / 40f;
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
        pion.GetComponent<Rigidbody>().useGravity = true;
        seMisca = false;
    }

    public IEnumerator inchisoare(Player p)
    {
        p.inchisoare = true;
        nrPlayers[p.poz]--;
        yield return StartCoroutine(misca(p.pion, p.pion.transform.position, pozPioni[40, nrPlayers[40]]));
        nrPlayers[40]++;
        players[laRand].poz = 40;
    }
}
