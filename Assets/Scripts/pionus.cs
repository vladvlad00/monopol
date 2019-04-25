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
    GameObject dis;
    public static int i = 0;
    static float x = 905f;
    int k = 0;
    int[] uz = new int[6];
    void Start()
    {
        verif();
        transform.position = new Vector3(1000, 2500, 1000);
        dis = Instantiate(modele[i], transform.position, Quaternion.Euler(270f, 180f, 0f));
        for (int i = 0; i < 6; i++)
            uz[i] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        verif();
    }
    public void dr()
    {
        i++;
        if (i > 5) i = 0;
        reRender();
        verif();
    }

    void verif()
    {
        if(uz[i] == 1)
        {
            s.interactable = false;
            p.enabled = true;
        }
        else
        {
            s.interactable = true;
            p.enabled = false;
        }
    }

    public void reseti()
    {
        i = 0;
        reRender();
        verif();
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
