using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proprietate2 : MonoBehaviour
{
    public Player owner;
    public string nume;
    public int pret;
    public int ipoteca; //ca sa cumperi inapoi ipoteca*1.1
    public int id;
    public bool ipotecat = false;
    public string SID = "neh";
    public bool ownedByBank = true;

    //Initializare
    public Proprietate2(string n, int p, int i, int cod, string s)
    {
        nume = n;
        pret = p;
        ipoteca = i;
        id = cod;
        SID = s;
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
        Base.banca.plata(owner, pret / 2);
        ipotecat = true;
    }
    //scoti ipoteca
    public void deIpotecare()
    {
        owner.plata(Base.banca, ((pret / 2) * 11) / 10);
        ipotecat = false;
    }

    public int numarGari()
    {
        int nr = 0;
        foreach(Proprietate2 p in Base.gari)
        {
            if (p.owner.id == owner.id && p.owner.id != Base.banca.id) nr++;
        }
        return nr;
    }
}