using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int nrPlayers=0;
    public int money;
    public string nume = "player";
    public int id = 0; //Nr. player
    public int poz = 0; //0 e start, 10*n colturi, 5 15 25 35 gari etc.
    public GameObject pion;
    public bool inchisoare;

    public Player(string n, GameObject p)
    {
        nume = n;
        pion = p;
        poz = 0;
        money = 9999999;
        if (p != null)
        {
            id = nrPlayers++;
            Base.nrPlayers[0]++;
            money = 1500;
        }
    }

    //Cheltuiesti bani, daca nu ai destul apare doar mesaj
    public void plata(Player p, int suma)
    {
        money -= suma;
        p.money += suma;
    }
    //Daca pierzi
    public void Bankrupt()
    {

    }
    
    public void trade(Player p, int baniDati, int baniPrimiti, Proprietate[] propDate, Proprietate[] propPrimite)
    {
        plata(p, baniDati);
        p.plata(this, baniPrimiti);
        foreach (Proprietate i in propDate)
            i.SetOwner(p);
        foreach (Proprietate i in propPrimite)
            i.SetOwner(this);
    }

    public void buyProp(Proprietate p)
    {
        plata(Base.banca, p.pret);
        p.SetOwner(this);
    }

    
}
