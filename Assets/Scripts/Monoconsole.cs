using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monoconsole : MonoBehaviour
{
    public GameObject Consovas;
    public GameObject Consotext;
    string comanda = null;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            Consovas.SetActive(!Consovas.activeSelf);
            if(Consovas.activeSelf) Consovas.GetComponentInChildren<InputField>().ActivateInputField();
        }
        if (Consovas.activeSelf)
        {
            if(comanda!= null)
            {
                // p player
                // a,b,c,d proprietate
                // g gara
                // u utilitate
                // mm bani minus
                // mp bani plus
                // sp set bani pozitiv
                // sn set bani negativ
                // w win
                // l lose
                // np nr case plus
                // nm nr case minus
                // k banca
                char[] c = comanda.ToCharArray();
                if(c[0] == 'p')
                {
                    int idp = c[1] - '0';
                    int ida;
                    if(c[2] == 'a')
                    {
                        ida = c[3] - '0';
                        ida += 1;
                        Base.props[ida].SetOwner(Base.players[idp]);
                    }
                    else if(c[2] == 'b')
                    {
                        ida = c[3] - '0';
                        ida += 11;
                        Base.props[ida].SetOwner(Base.players[idp]);
                    }
                    else if (c[2] == 'c')
                    {
                        ida = c[3] - '0';
                        ida += 21;
                        Base.props[ida].SetOwner(Base.players[idp]);
                    }
                    else if (c[2] == 'd')
                    {
                        ida = c[3] - '0';
                        ida += 31;
                        Base.props[ida].SetOwner(Base.players[idp]);
                    }
                    else if(c[2] == 'g')
                    {
                        ida = c[3] - '0';
                        Base.gari[ida].SetOwner(Base.players[idp]);
                    }
                    else if (c[2] == 'u')
                    {
                        ida = c[3] - '0';
                        Base.util[ida].SetOwner(Base.players[idp]);
                    }
                    else if(c[2] == 'm')
                    {
                        if (c[3] == 'p')
                        {
                            ida = 0;
                            int i = 4;
                            while (nr(c[i]))
                            {
                                ida = ida * 10 + (c[i] - '0');
                                i++;
                            }
                            Base.players[idp].money += ida;
                        }
                        else if(c[3] == 'n')
                        {
                            ida = 0;
                            int i = 4;
                            while (nr(c[i]))
                            {
                                ida = ida * 10 + (c[i] - '0');
                                i++;
                            }
                            Base.players[idp].money -= ida;
                        }
                    }
                    else if(c[2] == 's')
                    {
                        if (c[3] == 'p')
                        {
                            ida = 0;
                            int i = 3;
                            while (nr(c[i]))
                            {
                                ida = ida * 10 + (c[i++] - '0');
                            }
                            Base.players[idp].money = ida;
                        }
                        else if(c[3] == 'n')
                        {
                            ida = 0;
                            int i = 3;
                            while (nr(c[i]))
                            {
                                ida = ida * 10 + (c[i++] - '0');
                            }
                            Base.players[idp].money = (-1) * ida;
                        }
                    }
                    else if(c[2] == 'w')
                    {
                        foreach(Player pp in Base.players)
                        {
                            if (pp.id != Base.players[idp].id) pp.lost();
                        }
                    }
                    else if(c[2] == 'l')
                    {
                        Base.players[idp].lost();
                    }
                }
                else if(c[0] == 'a' || c[0] == 'b' || c[0] == 'c' || c[0] == 'd')
                {
                    int ida = 1 + (c[1] - '0') + 10 * (c[0] - 'a');
                    if(c[2] == 'n')
                    {
                        if(c[3] == 'p')
                        {
                            int x = Base.props[ida].numarCase;
                            if (x < 5) Base.props[ida].numarCase++;
                        }
                        if(c[3] == 'm')
                        {
                            int x = Base.props[ida].numarCase;
                            if (x > 0) Base.props[ida].numarCase--;
                        }
                    }
                    else if(c[2] == 'k')
                    {
                        Base.props[ida].numarCase = 0;
                        Base.props[ida].SetOwner(Base.banca);
                    }
                }
                comanda = null;
                UImagic.schimbat = true;
            }
        }
    }

    bool nr(char c)
    {
        if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9') return true;
        return false;
    }

    public void enter()
    {
        comanda = Consovas.GetComponentInChildren<InputField>().text + '~';
        Consovas.GetComponentInChildren<InputField>().text = null;
        Consovas.GetComponentInChildren<InputField>().ActivateInputField();
    }
}
