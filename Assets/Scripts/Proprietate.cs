using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proprietate : MonoBehaviour
{
    public Player owner;
    public Player lastOwn = Base.banca;
    public string nume;
    public string categorie;
    public int pret;
    public int[] chirie = new int[6];
    public int chiried;
    public int oldchir;
    public int ipoteca; //ca sa cumperi inapoi ipoteca*1.1
    public int costCasa;
    public int numarCase = 0;
    public int id;
    public bool ipotecat = false;
    public bool isInTrade = false;
    public bool hotel = false;
    public string SID = "neh";
    public bool ownedByBank = true;
    public GameObject[] casute = new GameObject[4];
    public static GameObject modelCasa;
    public static GameObject modelHotel;

    //Initializare
    public Proprietate(string n, int p, int i, int cc, int cod, string cat, string s)
    {
        nume = n;
        pret = p;
        ipoteca = i;
        costCasa = cc;
        id = cod;
        categorie = cat;
        SID = s;
    }
    //Cumpara o casa
    public void Build()
    {
        if (owner.money - costCasa < 0) UImagic.showERR = 4; //bani
        else
        {
            if (CanBuild())
            {
                if (numarCase < 5)
                {
                    owner.plata(Base.banca, costCasa);
                    if (numarCase < 4)
                    {
                        casute[numarCase] = Instantiate(modelCasa, Base.pozCase[id, numarCase], Quaternion.Euler(-90, (id + 7) / 6 * 90, 0)) as GameObject;
                        casute[numarCase].transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                            Destroy(casute[i]);
                        casute[0] = Instantiate(modelHotel, Base.pozCase[id, 1], Quaternion.Euler(-90, (id + 7) / 6 * 90, 0)) as GameObject;
                        casute[0].transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    }
                    numarCase++;
                    Updateprop();
                    setPreviewProp.crtID = SID;
                }
                else UImagic.showERR = 7; // prea multe
            }
            else UImagic.showERR = 5; //numar inegal
        }
    }

    public void Updateprop()
    {
        foreach(Proprietate p in Base.props)
        {
            if (p.categorie == categorie) p.Updateprop2();
        }
    }

    public void Updateprop2()
    {
        bool ok = true;
        foreach(Proprietate p in Base.props)
        {
            if(p.categorie == categorie)
            {
                if (p.owner.id != owner.id) ok = false;
                if (p.numarCase > 0) ok = false;
                if (p.owner.id == Base.banca.id) ok = false;
                if (p.ipotecat == true) ok = false;
            }
        }
        if (ok) chirie[0] = chiried;
        else chirie[0] = oldchir;
    }
    //Vinde o casa
    public void Demolish()
    {
        if (numarCase > 0)
        {
            Base.banca.plata(owner, costCasa / 2);
            if (numarCase == 5)
            {
                Destroy(casute[0]);
                for (int i = 0; i < 4; i++)
                {
                    casute[i] = Instantiate(modelCasa, Base.pozCase[id, i], Quaternion.Euler(-90, (id + 7) / 6 * 90, 0)) as GameObject;
                    casute[i].transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                }
            else
                Destroy(casute[numarCase - 1]);
            numarCase--;
            Updateprop();
            setPreviewProp.crtID = SID;
        }
        else UImagic.showERR = 6; //macar 1 casa
    }
    //Verifica daca poti construi casa
    bool CanBuild()
    {
        bool ok = true;
        foreach (Proprietate p in Base.props)
        {
            if (p.categorie == categorie)
            {
                if (p.owner.id != owner.id) ok = false;
                if (p.numarCase < numarCase) ok = false;
            }
        }
        return ok;
    }
    //Setezi detinator
    public void SetOwner(Player p)
    {
        owner = p;
        ownedByBank = false;
        if (p.id == 100) ownedByBank = true;
    }
    //Ipotechezi proprietatea
    public void Ipotecare()
    {
        if (!ipotecat)
        {
            Base.banca.plata(owner, pret / 2);
            ipotecat = true;
        }
    }
    // scoti ipoteca
    public void deIpotecare()
    {
        if (ipotecat)
        {
            owner.plata(Base.banca, ((pret / 2) * 11) / 10);
            ipotecat = false;
        }
    }

}