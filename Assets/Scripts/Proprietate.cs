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
    public int ipoteca; //ca sa cumperi inapoi ipoteca*1.1
    public int costCasa;
    public int numarCase = 0;
    public int id;
    public bool ipotecat = false;
    public bool isInTrade = false;
    public bool hotel = false;

    //Initializare
    public Proprietate(string n, int p, int i, int cc, int cod, string cat)
    {
        nume = n;
        pret = p;
        ipoteca = i;
        costCasa = cc;
        id = cod;
        categorie = cat;
    }
    //Cumpara o casa
    void Build()
    {
        
    }
    //Vinde o casa
    void Demolish()
    {
        
    }
    //Verifica daca poti construi casa
    bool CanBuild()
    {
        bool ok = true;
        foreach (Proprietate p in Base.props)
        {
            if (p.categorie == categorie)
            {
                if (p.owner != owner) ok = false;
                else if (p.numarCase + 1 > numarCase) ok = false;
            }
        }
        return ok;
    }
    //Setezi detinator
    public void SetOwner(Player p)
    {
        owner = p;
    }
    //Ipotechezi proprietatea
    void Ipotecare()
    {
        Base.banca.plata(owner,pret/2);
        ipotecat = true;
        SetOwner(Base.banca);
    }

}