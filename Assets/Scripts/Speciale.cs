using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speciale : MonoBehaviour
{
    public IEnumerator sansa(Player p, int nr)
    {
        int i;

        yield return new WaitForSeconds(0.01f);
        switch (nr)
        {
            case 0: p.plata(Base.banca, 15); break; //-15
            case 1: //mergi cea mai apropiata gara + chirie dubla
                for (i = p.poz + 1; i % 10 != 5; i++) ;
                i %= 40;
                if (i < p.poz)
                    Base.banca.plata(p, 200);
                deplasare(p,i);
                break;
            case 2: break;//inchisoare
            case 3: //mergi prima gara
                if (5 < p.poz)
                    Base.banca.plata(p, 200);
                deplasare(p, 5);
                break;
            case 4: //mergi a 3 rosie
                if (23 < p.poz)
                    Base.banca.plata(p, 200);
                deplasare(p, 23);
                break;
            case 5: //mergi 3 inapoi
                deplasare(p, p.poz - 3);
                break;
            case 6: //+150
                Base.banca.plata(p, 150);
                break;
            case 7: //reparatii 25/100
                int suma = 0;
                foreach (Proprietate x in Base.props)
                {
                    if (x.owner == p)
                    {
                        if (x.numarCase == 5)
                            suma += 100;
                        else suma += x.numarCase * 25;
                    }
                }
                p.plata(Base.banca, suma);
                break;
            case 8: //+50
                Base.banca.plata(p, 50);
                break;
            case 9: //platesti 50 la fiecare player
                foreach (Player x in Base.players)
                    if (x != p)
                        p.plata(x, 50);
                break;
            case 10: //mergi start
                Base.banca.plata(p, 200);
                deplasare(p, 0);
                break;
            case 11: //mergi la a 2 albastru inchis
                deplasare(p, 39);
                break;
            case 12: //mergi cea mai apropiata gara + chirie dubla
                for (i = p.poz + 1; i % 10 != 5; i++) ;
                i %= 40;
                if (i < p.poz)
                    Base.banca.plata(p, 200);
                deplasare(p, i);
                break;
            case 13: //mergi cea mai apropiata utilitate, dai cu 1 zar, platesti 10x
                if (p.poz > 12 && p.poz < 18)
                    i = 18;
                else i = 12;
                if (i < p.poz)
                    Base.banca.plata(p, 200);
                deplasare(p, i);
                break;
            case 14: break;//iesi inchisoare
            case 15: //mergi la prima roz
                if (11 < p.poz)
                    Base.banca.plata(p, 200);
                deplasare(p, 11);
                break;
        }
    }

    public IEnumerator cufar(Player p, int nr)
    {
        yield return new WaitForSeconds(0.01f);
        switch (nr)
        {
            case 0: break;//iesi inchisoare
            case 1: //+25
                Base.banca.plata(p, 25);
                break;
            case 2: //reparatii 40/115
                int suma = 0;
                foreach (Proprietate x in Base.props)
                {
                    if (x.owner == p)
                    {
                        if (x.numarCase == 5)
                            suma += 100;
                        else suma += x.numarCase * 25;
                    }
                }
                p.plata(Base.banca, suma);
                break;
            case 3: //primesti 10 de la fiecare player
                foreach (Player x in Base.players)
                    if (x != p)
                        x.plata(p, 10);
                break;
            case 4: break; //inchisoare
            case 5: //+100
                Base.banca.plata(p, 100);
                break;
            case 6: //-50
                p.plata(Base.banca, 50);
                break;
            case 7: //-50
                p.plata(Base.banca, 50);
                break;
            case 8: //+20
                Base.banca.plata(p, 20);
                break;
            case 9: //+50
                Base.banca.plata(p, 50);
                break;
            case 10: //-100
                p.plata(Base.banca, 100);
                break;
            case 11: //+10
                Base.banca.plata(p, 10);
                break;
            case 12: //+100
                Base.banca.plata(p, 100);
                break;
            case 13: //+100
                Base.banca.plata(p, 100);
                break;
            case 14: //mergi start
                Base.banca.plata(p, 200);
                deplasare(p, 0);
                break;
        }
    }

    void deplasare(Player p, int i)
    {
        Base.nrPlayers[p.poz]--;
        StartCoroutine(Base.misca(p.pion,p.pion.transform.position, Base.pozPioni[i, Base.nrPlayers[i]]));
        Base.nrPlayers[i]++;
        p.poz = i;
    }
}