using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pionus : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] modele = new GameObject[6];
    public Button b; // buton start joc
    public Text t; // text minim 2 playeri
    public Button s; // buton selectat pion
    public Text p; // text deja selectat
    public Text p2; // deja nume
    public Text p3; // nu gol
    public InputField nume; //numele scris
    GameObject dis;
    public static int i = 0;
    static float x = 905f;
    public static int k = 0;
    int[] uz = new int[6];
    void Start()
    {
        //s.interactable = (verif() && verif2() && verif3());
        transform.position = new Vector3(1000, 2500, 1000);
        dis = Instantiate(modele[i], transform.position, Quaternion.Euler(270f, 180f, 0f));
        for (int i = 0; i < 6; i++)
            uz[i] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool a1 = verif();
        bool a2 = verif2();
        bool a3 = verif3();
        s.interactable = (a1 && a2 && a3);
    }
    //nu stiu sa folosesc statice
    void DrawText(Vector3 poz, string textul, int size, Color cl, float rotX, float rotY)
    {
        Font ArialF = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        GameObject myText = new GameObject();
        Font Kabel = Resources.Load<Font>("Fonts/Kabel-Heavy");
        Material KabelMat = Resources.Load<Material>("Fonts/Kabel-Heavy");

        myText.transform.position = poz;

        TextMesh plsText = myText.AddComponent<TextMesh>();

        plsText.text = textul;
        plsText.fontSize = size;
        plsText.font = Kabel;
        plsText.font.material = KabelMat;
        plsText.color = cl;
        plsText.anchor = TextAnchor.UpperCenter;
        plsText.alignment = TextAlignment.Center;
        plsText.lineSpacing = 1.5f;
        //plsText.fontStyle = FontStyle.Bold;

        MeshRenderer rend = myText.GetComponent<MeshRenderer>();
        rend.material = KabelMat;

        myText.transform.Rotate(rotX, rotY, 0f, 0f);
    }

    public void reRender()
    {
        Destroy(dis);
        dis = Instantiate(modele[i], transform.position, Quaternion.Euler(270f, 180f, 0f));
    }

    public void st()
    {
        i--;
        if (i < 0) i = 5;
        reRender();
        //s.interactable = (verif() && verif2() && verif3());
    }
    public void dr()
    {
        i++;
        if (i > 5) i = 0;
        reRender();
        //s.interactable = (verif() && verif2() && verif3());
    }

    bool verif()
    {
        if(uz[i] == 1)
        {
            p.enabled = true;
            return false;
        }
        else
        {
            p.enabled = false;
            return true;
        }
    }
    
    bool verif2()
    {
        bool ok = true;
        if (Player.nrPlayers > 0)
        {
            foreach (Player p in Base.players)
                if (p.nume == nume.text)
                    ok = false;
        }
        if(ok)
        {
            p2.enabled = false;
            return true;
        }
        else
        {
            p2.enabled = true;
            return false;
        }
    }

    bool verif3()
    {
        if (nume.text == "")
        {
            p3.enabled = true;
            return false;
        }
        else
        {
            p3.enabled = false;
            return true;
        }
    }
    public void reseti()
    {
        i = 0;
        reRender();
        //s.interactable = (verif() && verif2() && verif3());
    }

    public void previewp()
    {
        float z = 950f;
        GameObject pp = Instantiate(modele[i], new Vector3(x, 5001f, z-20f), Quaternion.Euler(270f, 180f, 0f));
        DrawText(new Vector3(x, 5031f, z), Base.players[k].nume, 70, Color.black, 0f, 0f);
        x += 36f;
        k++;
        if(k == 2)
        {
            b.interactable = true;
            t.enabled = false;
        }
        uz[i] = 1;
    }
}
