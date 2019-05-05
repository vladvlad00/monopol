using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int nrPlayers=0;
    public int money;
    public string nume = "player";
    public int id = 0; //Nr. player
    public int poz = 0; //0 e start, 10*n colturi, 5 15 25 35 gari etc.
    public GameObject pion;
    public bool inchisoare;
    public bool pierdut;
    public int dubleInchisoare;
    public bool platit50;
    public Text err3;

    public Player(string n, GameObject p)
    {
        nume = n;
        pion = p;
        poz = 0;
        money = 9999999;
        pierdut = false;
        if (p != null)
        {
            id = nrPlayers++;
            Base.nrPlayers[0]++;
            inchisoare = false;
            money = 1500;
        }
    }

    //Cheltuiesti bani, daca nu ai destul apare doar mesaj
    public void plata(Player p, int suma)
    {
        money -= suma;
        p.money += suma;
        if (money < 0) Bankrupt();
        UImagic.schimbat = true;
    }
    //Daca pierzi
    public void Bankrupt()
    {
        int val = 0;
        foreach(Proprietate p in Base.props)
        {
            if (p.owner.id == id) val += (p.ipoteca + p.numarCase * p.costCasa); 
        }
        foreach(Proprietate2 p in Base.util)
        {
            if (p.owner.id == id) val += p.ipoteca;
        }
        foreach (Proprietate2 p in Base.gari)
        {
            if (p.owner.id == id) val += p.ipoteca;
        }
        if (money + val < 0) lost();
        else UImagic.showERR = 2;
    }
    
    public void lost()
    {
        UImagic.lostplayer = Base.players[Base.laRand].nume;
        UImagic.showERR = 3;
        pierdut = true;
        foreach(Proprietate p in Base.props)
        {
            if (p.owner.id == id) p.SetOwner(Base.banca);
        }
        foreach(Proprietate2 p in Base.gari)
        {
            if (p.owner.id == id) p.SetOwner(Base.banca);
        }
        foreach(Proprietate2 p in Base.util)
        {
            if (p.owner.id == id) p.SetOwner(Base.banca);
        }
        Destroy(pion);
    }

    public void trade(Player p, int baniDati, int baniPrimiti, Proprietate[] propDate, Proprietate[] propPrimite, Proprietate2[] gariDate, Proprietate2[] gariPrimite, Proprietate2[] utilDate, Proprietate2[] utilPrimite)
    {
        plata(p, baniDati);
        p.plata(this, baniPrimiti);
        foreach (Proprietate i in propDate)
        {
            if (i.id == -1)
                continue;
            foreach (Proprietate j in Base.props)
                if (i.id == j.id)
                {
                    i.SetOwner(p);
                    j.SetOwner(p);
                }
        }
        foreach (Proprietate i in propPrimite)
        {
            if (i.id == -1)
                continue;
            foreach (Proprietate j in Base.props)
                if (i.id == j.id)
                {
                    i.SetOwner(this);
                    j.SetOwner(this);
                }
        }
        foreach (Proprietate2 i in gariDate)
        {
            if (i.id == -1)
                continue;
            foreach (Proprietate2 j in Base.gari)
                if (i.id == j.id)
                {
                    i.SetOwner(p);
                    j.SetOwner(p);
                }
        }
        foreach (Proprietate2 i in gariPrimite)
        {
            if (i.id == -1)
                continue;
            foreach (Proprietate2 j in Base.gari)
                if (i.id == j.id)
                {
                    i.SetOwner(this);
                    j.SetOwner(this);
                }
        }
        foreach (Proprietate2 i in utilDate)
        {
            if (i.id == -1)
                continue;
            foreach (Proprietate2 j in Base.util)
                if (i.id == j.id)
                {
                    i.SetOwner(p);
                    j.SetOwner(p);
                }
        }
        foreach (Proprietate2 i in utilPrimite)
        {
            if (i.id == -1)
                continue;
            foreach (Proprietate2 j in Base.util)
                if (i.id == j.id)
                {
                    i.SetOwner(this);
                    j.SetOwner(this);
                }
        }
        foreach (Proprietate i in Base.props)
            i.Updateprop2();
    }

    public void buyProp(Proprietate p)
    {
        if (money - p.pret > 0)
        {
            plata(Base.banca, p.pret);
            p.SetOwner(this);
            Base.offBuyScreen();
            p.ownedByBank = false;
            p.Updateprop();
        }
        else UImagic.showERR = 1;
    }
    public void buyProp2(Proprietate2 p)
    {
        if (money - p.pret > 0)
        {
            plata(Base.banca, p.pret);
            p.SetOwner(this);
            Base.offBuyScreen();
            p.ownedByBank = false;
        }
        else UImagic.showERR = 1;
    }
}
