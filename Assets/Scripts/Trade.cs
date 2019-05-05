using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trade : MonoBehaviour
{
    public GameObject ddst;
    public GameObject dddr;
    public GameObject ifst;
    public GameObject ifdr;
    string numeST = null;
    string numeDR = null;
    public static Player plST;
    public static Player plDR;

    public static Proprietate[] pST = new Proprietate[30];
    public static int nrpST = 0;
    public static Proprietate[] pDR = new Proprietate[30];
    public static int nrpDR = 0;
    public static Proprietate2[] gST = new Proprietate2[10];
    public static int nrgST = 0;
    public static Proprietate2[] gDR = new Proprietate2[10];
    public static int nrgDR = 0;
    public static Proprietate2[] uST = new Proprietate2[5];
    public static int nruST = 0;
    public static Proprietate2[] uDR = new Proprietate2[5];
    public static int nruDR = 0;
    public static int moneyST;
    public static int moneyDR;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(trade);
        ddst.GetComponent<Dropdown>().ClearOptions();
        dddr.GetComponent<Dropdown>().ClearOptions();
        List<string> sOptions = new List<string>();
        sOptions.Add("aux");
        foreach(Player p in Base.players)
        {
            sOptions.Add(p.nume);
        }
        ddst.GetComponent<Dropdown>().AddOptions(sOptions);
        dddr.GetComponent<Dropdown>().AddOptions(sOptions);
        foreach (Player p in Base.players) if (p.nume == numeST) plST = p;
        foreach (Player p in Base.players) if (p.nume == numeDR) plDR = p;
    }

    void trade()
    {
        if (numeST != null && numeDR != null && numeST != numeDR)
        {
            foreach (Player p in Base.players) if (p.nume == numeST) plST = p;
            foreach (Player p in Base.players) if (p.nume == numeDR) plDR = p;
            for (int i = nrpST; i < 30; i++)
                pST[i] = Base.nein;
            for (int i = nrpDR; i < 30; i++)
                pDR[i] = Base.nein;
            for (int i = nrgST; i < 10; i++)
                gST[i] = Base.nein2;
            for (int i = nrgDR; i < 10; i++)
                gDR[i] = Base.nein2;
            for (int i = nruST; i < 5; i++)
                uST[i] = Base.nein2;
            for (int i = nruDR; i < 5; i++)
                uDR[i] = Base.nein2;
            plST.trade(plDR, moneyST, moneyDR, pST, pDR, gST, gDR, uST, uDR);
        }
        else Debug.Log("something went wrong");
    }
    /*
    void Update()
    {
        if (numeST != null && numeDR != null && numeST != numeDR)
        {
            Debug.Log(numeST);
            foreach (Player p in Base.players) if (p.nume == numeST) plST = p;
            foreach (Player p in Base.players) if (p.nume == numeDR) plDR = p;
        }
    }
    */
    public void upST()
    {
        numeST = ddst.GetComponent<Dropdown>().captionText.text;
        foreach (Player p in Base.players) if (p.nume == numeST) plST = p;
        if (numeST == numeDR)
        {
            UImagic.showERR = 11;
            ddst.GetComponent<Dropdown>().value = 0;
            numeST = null;
        }
    }

    public void upDR()
    {
        numeDR = dddr.GetComponent<Dropdown>().captionText.text;
        foreach (Player p in Base.players) if (p.nume == numeDR) plDR = p;
        if (numeDR == numeST)
        {
            UImagic.showERR = 11;
            dddr.GetComponent<Dropdown>().value = 0;
            numeDR = null;
        }
    }

    public void iaBaniST()
    {
        char[] c = ifst.GetComponentInChildren<InputField>().text.ToCharArray();
        foreach(char cc in c)
        {
            Debug.Log(c);
            if (cc != '0' && cc != '1' && cc != '2' && cc != '3' && cc != '4' && cc != '5' && cc != '6' && cc != '7' && cc != '8' && cc != '9') return;
        }
        moneyST = int.Parse(ifst.GetComponentInChildren<InputField>().text);
    }

    public void iaBaniDR()
    {
        char[] c = ifdr.GetComponentInChildren<InputField>().text.ToCharArray();
        foreach (char cc in c)
        {
            Debug.Log(c);
            if (cc != '0' && cc != '1' && cc != '2' && cc != '3' && cc != '4' && cc != '5' && cc != '6' && cc != '7' && cc != '8' && cc != '9') return;
        }
        moneyDR = int.Parse(ifdr.GetComponentInChildren<InputField>().text);
    }
}
