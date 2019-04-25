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

    //Initializare
    public Proprietate2(string n, int p, int i, int cod)
    {
        nume = n;
        pret = p;
        ipoteca = i;
        id = cod;
    }
    //Setezi detinator
    public void SetOwner(Player p)
    {
        owner = p;
    }
    //Ipotechezi proprietatea
    void Ipotecare()
    {
        Base.banca.plata(owner, pret / 2);
        ipotecat = true;
        SetOwner(Base.banca);
    }

}